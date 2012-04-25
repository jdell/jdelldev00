using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Packaging;
using System.IO;
using System.Xml;

namespace com.mxply.net.logging
{
    internal abstract class Zipper
    {
        private static String GetFullPath(string zipName)
        {
            try
            {
                string res = System.IO.Path.Combine(Config.VirtualPath, Config.ZipTempFolder);
                if (!Directory.Exists(res))
                    Directory.CreateDirectory(res);

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //internal static void Add(String zipName, Documento documento)
        //{
        //    try
        //    {
        //        // Añadimos el propio fichero al Zip     
        //        Zipper.Add(zipName, documento.Titulo, documento.Content);

        //        // Creamos el xml con el cove y tambien lo añadimos
        //        Zipper.Add(zipName, "CodigoDeVerificacionElectronica.xml", GetXmlContent(documento));

        //        //Buscamos el informe de firma y tambien lo añadimos
        //        using (System.Net.WebClient wc = new System.Net.WebClient())
        //            Zipper.Add(zipName, "ReciboElectronicoDeSinatura.pdf", wc.DownloadData(documento.URLInforme));

        //        //añadimos archivo PKCS7 (.p7s)
        //        //TODO: Refactorizar XestionFirma
        //        xestionfirma.Firmas firma = xestionfirma.FirmasXml.DeserializarXmlFirmas(documento.Firma);
        //        Zipper.Add(zipName, "SinaturaElectronica.p7s", Convert.FromBase64String(firma.Signatario[0].Firma.Hash));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        private static void Add(String zipName, String fileName, Byte[] fileContent)
        {
            try
            {
                using (Package zip = System.IO.Packaging.Package.Open(GetFullPath(zipName), FileMode.OpenOrCreate))
                {
                    Uri uri = PackUriHelper.CreatePartUri(new Uri(String.Format(".\\{0}", Path.GetFileName(fileName)), UriKind.Relative));
                    if (zip.PartExists(uri))
                        zip.DeletePart(uri);

                    PackagePart part = zip.CreatePart(uri, "", CompressionOption.Maximum);
                    using (MemoryStream input = new MemoryStream(fileContent))
                    using (Stream output = part.GetStream())
                        input.CopyTo(output);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal static Byte[] GetContent(String zipName, bool delete)
        {
            try
            {
                Byte[] res = File.Exists(GetFullPath(zipName)) ? File.ReadAllBytes(GetFullPath(zipName)) : null;
                if (delete && res != null)
                    File.Delete(GetFullPath(zipName));

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
