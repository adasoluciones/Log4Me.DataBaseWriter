using Ada.Framework.Development.Log4Me.Entities;
using System.IO;
using System.Text;

namespace Ada.Framework.Development.Log4Me.Writers.ConsoleWrite
{
    public class ConsoleTextWriter : TextWriter
    {
        public override Encoding Encoding { get { return Encoding.Unicode; } }

        public override void Write(string mensaje)
        {
            Log4MeManager.CurrentInstance.Mensaje(mensaje, Nivel.Debug);
        }
    }
}
