using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Collections.Generic;
using Test_Gastos.Models;
using System.Text.RegularExpressions;

namespace Test_Gastos.Controllers
{
    public class SessionController : Controller
    {
        public UserToken UsuarioActivo => new UserToken(HttpContext.User);
        public byte[] FormFileToBytes(IFormFile file)
        {
            byte[] bytes;
            using (var stream = file.OpenReadStream())
            {
                using (var ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    bytes = ms.ToArray();
                }
            }
            return bytes;
        }        
        public decimal ObtenerTamañoArchivoEnKilobytes(IFormFile file)
        {
            return file.Length / 1024;
        }
        public decimal ObtenerTamañoArchivoEnMegabytes(IFormFile file)
        {
            return file.Length / (1024 * 1024);
        }
        public static string QuitarTildes(string cadena)
        {
            return Regex.Replace(cadena, @"[áÁàÀäÄâÂéÉèÈëËêÊíÍìÌïÏîÎóÓòÒöÖôÔúÚùÙüÜûÛçÇ]", m =>
            {
                string valor = m.Value.ToLower();
                switch (valor)
                {
                    case "á": case "à": case "ä": case "â": return "a";
                    case "é": case "è": case "ë": case "ê": return "e";
                    case "í": case "ì": case "ï": case "î": return "i";
                    case "ó": case "ò": case "ö": case "ô": return "o";
                    case "ú": case "ù": case "ü": case "û": return "u";
                    case "ç": return "c";
                    default: return valor;
                }
            });
        }



        public string UrlFile(string routeFile)
        {
            try
            {
                string? routeUrl = Url.Action("Index", "Home");
                string scheme = string.Format("{0}://", Request.Scheme);
                string absUrl = string.Format("{0}/{1}/{2}", Request.Host, routeUrl, routeFile);
                absUrl = absUrl.Replace("//", "/").Replace("//", "/").Replace("//", "/");
                return $"{scheme}{absUrl}";
            }
            catch
            {
                throw;
            }
        }
        public T? Get<T>(string key)
        {

            try
            {
                return SessionExtensions.Get<T>(HttpContext.Session, key);
            }
            catch
            {
                return default(T);
            }
        }
        public void Set<T>(string key, T value)
        {
            try
            {
                SessionExtensions.Set(HttpContext.Session, key, value);
            }
            catch
            {
                throw;
            }
        }
        public void RemoveSession(string key)
        {
            SessionExtensions.Remove(HttpContext.Session, key);
        }

        #region Alertas & Toast
        public enum NotifyIcon
        {
            success = 1,
            info = 2,
            warning = 3,
            danger = 4
        }
        public void LimpiarAlerta()
        {
            Set(SessionKeys.Alerta, string.Empty);
        }
        public void AddAlerta(string texto, NotifyIcon tipo = NotifyIcon.info)
        {
            string? scripts = Get<string>(SessionKeys.Alerta);
            scripts += " " + $"Alert(\"{texto}\",NotifyIcon.{tipo.ToString()});";
            Set(SessionKeys.Alerta, scripts);
        }
        public void AddToast(string texto, NotifyIcon tipo = NotifyIcon.info)
        {
            string? scripts = Get<string>(SessionKeys.Toast);
            scripts += " " + $"Notify(\"{texto}\",NotifyIcon.{tipo.ToString()});";
            Set(SessionKeys.Toast, scripts);
        }
        public void LimpiarToast()
        {
            Set(SessionKeys.Toast, string.Empty);
        }

        public string UrlResources(string route)
        {
            try
            {
                string? routeUrl = Url.Action("Index", "Home");
                string scheme = string.Format("{0}://", Request.Scheme);
                string absUrl = string.Format("{0}/{1}/{2}", Request.Host, routeUrl, route);
                absUrl = absUrl.Replace("//", "/").Replace("//", "/").Replace("//", "/");
                return $"{scheme}{absUrl}";
            }
            catch
            {
                return string.Empty;
            }
        }
        public string PathFile(string route)
        {
            try
            {
                string pathReturn = string.Empty;
                var pathRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (pathRoot != null && pathRoot.Contains("\\bin"))
                    pathRoot = pathRoot.Substring(0, pathRoot.IndexOf("\\bin"));
                pathReturn = $"{pathRoot}{route}";
                pathReturn = pathReturn.Replace(@"\\", @"\");
                return pathReturn;
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion

        #region SAVE FILES
        public string? GuardarImagenes(IFormFile? adjunto = null, string carpeta = "sin_carpeta")
        {
            var randomNumber = new Random().Next(0, 100);
            string? url = null;
            if ((adjunto != null) && (adjunto.Length > 0) && !string.IsNullOrEmpty(adjunto.FileName))
            {
                string fileName = adjunto.FileName;
                string[] separarNombre = fileName.Split('.');
                string extension = separarNombre[1];

                string directorio = $"{PathFile($@"\wwwroot\img\{carpeta}\")}";
                string route = $@"{directorio}\{""}";

                if (!Directory.Exists(directorio))
                    Directory.CreateDirectory(directorio);

                string nameFile = $@"{separarNombre[0]}{randomNumber}.png";
                url = $@"{directorio}\{nameFile}";
                using (var stream = System.IO.File.Create(url))
                {
                    adjunto.CopyToAsync(stream);
                }

                url = UrlResources($@"/img/{carpeta}/{nameFile}");
            }
            return url;
        }
        #endregion

        #region VALID NULLS
        public string NullString(string cadena="",int upper=1)
        {
            string respuesta = "";
            try
            {
                if (cadena == null)
                    respuesta = "";
                else if (cadena == "")
                    respuesta = "";
                else if(upper==1)
                    respuesta = cadena.ToUpper();
                else
                    respuesta = cadena;
            }
            catch
            {
                respuesta = "";
            }
            return respuesta;
        }
        public decimal NullDecimal(string cadena)
        {
            decimal respuesta = 0;
            try
            {
                if (cadena == null)
                    respuesta = 0;
                else if (cadena == "")
                    respuesta = 0;
                else
                    respuesta = Convert.ToDecimal(cadena);
            }
            catch
            {
                respuesta = 0;
            }
            return respuesta;
        }
        public int NullInt(string cadena)
        {
            int respuesta = 0;
            try
            {
                if (cadena == null)
                    respuesta = 0;
                else if (cadena == "")
                    respuesta = 0;
                else
                    respuesta = Convert.ToInt16(cadena);
            }
            catch
            {
                respuesta = 0;
            }
            return respuesta;
        }
        #endregion
    }
}