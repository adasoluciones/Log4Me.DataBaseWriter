using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ada.Framework.Development.Log4Me.Writers.ConsoleWrite
{
    [TestClass]
    public class ConsoleWriterUT
    {
        private ConsoleWriter cw = new ConsoleWriter();

        [TestMethod]
        public void TestMethod1()
        {
            cw.InterceptarSalida = true;
            cw.Inicializar();
            
            Console.WriteLine("Holaaa");
        }
    }
}
