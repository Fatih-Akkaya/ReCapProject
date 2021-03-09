using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Results;
using System.Threading.Tasks;

namespace Core.Utilities.Common
{
    public class FileManager
    {
        public static async Task<IResult> Add(string path, IFormFile file, bool renameGuid)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileExt = Path.GetExtension(file.FileName);
                string newFileName = renameGuid ? Guid.NewGuid().ToString() + fileExt : file.FileName;
                string FilePath = Path.Combine(path, newFileName);
                using (var fileStream = new FileStream(FilePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return new SuccessResult(newFileName);
            }
            catch (Exception exception)
            {
                return new ErrorResult("Dosya oluşturulurken bir hata oluştu");
            }
            
        }
        public static async Task<IResult> Update(string path, string oldFileName, IFormFile file, bool renameGuid)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileExt = Path.GetExtension(file.FileName);
                string newFileName = renameGuid ? Guid.NewGuid().ToString() + fileExt : file.FileName;
                string filePath = Path.Combine(path, newFileName);
                string oldFilePath= Path.Combine(path, oldFileName);
                if(File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return new SuccessResult(newFileName);
            }
            catch (Exception exception)
            {
                return new ErrorResult("Dosya güncellenirken bir hata oluştu");
            }

        }
        public static IResult Delete(string path, string fileName)
        {
            try
            {
                path = Path.Combine(path,fileName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return new SuccessResult();
                }
                return new ErrorResult();
            }
            catch (Exception exception)
            {
                return new ErrorResult("Dosya güncellenirken bir hata oluştu");
            }

        }
    }
}
