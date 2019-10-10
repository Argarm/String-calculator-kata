using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Save
{
    public class SaveFile : SaveInterface
    {
        public void save(String path,String log)
        {
            System.IO.File.AppendAllText(path, log);

        }

    }
}
