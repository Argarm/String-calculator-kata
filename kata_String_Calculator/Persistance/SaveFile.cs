using System;
using Model;

namespace PersistanceFile
{
    public class SaveFile : ISave
    {
        public void Save(String path,String log)
        {
            System.IO.File.AppendAllText(path, log+"\n");

        }

    }
}
