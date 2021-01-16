using System;
using System.IO;
namespace EstefaniasJeans.Extensions{
  public interface IFileManagment{
    string GuardarFromBase64(string folder, string base64, string nombre);
    void EliminarFromName(string folder, string nombre);
  }
  public class FileManagment : IFileManagment
  {
    public string GuardarFromBase64(string folder, string base64, string nombre)
    {
      var path = ValidarCarpeta(folder);
      var extension = ObtenerExtension(nombre);
      var nombreNuevo = GenerarNombre(extension);
      byte[] buffer = Convert.FromBase64String(base64);
      path = Path.Combine(path, nombreNuevo);
      File.WriteAllBytes(path, buffer);
      return nombreNuevo;
    }
    public void EliminarFromName(string folder, string nombre)
    {
      var path = ValidarCarpeta(folder);
      path = Path.Combine(path, nombre);
      File.Delete(path);
    }
    private string ValidarCarpeta(string folder){
      var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folder);
      if(!Directory.Exists(path)){
        Directory.CreateDirectory(path);
      }
      return path;
    }
    private string ObtenerExtension(string nombre){
      return Path.GetExtension(nombre);
    }
    private string GenerarNombre(string extension){
      return String.Format("{0}{1}", Guid.NewGuid(), extension);
    }
  }
}