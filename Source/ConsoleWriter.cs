using Ada.Framework.Development.Log4Me.Entities;
using Ada.Framework.Development.Log4Me.Writers.ConsoleWrite.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Writers.ConsoleWrite
{
    [Serializable]
    public class ConsoleWriter : ALogWriter
    {
        [XmlAttribute("InterceptOut")]
        public bool InterceptarSalida { get; set; }

        [XmlArray("ConsoleTypes")]
        [XmlArrayItem("ConsoleType")]
        public List<ConsoleTypeTag> NivelesSeguimiento { get; set; }

        [XmlIgnore]
        private TextWriter writer = new ConsoleTextWriter();

        public override void Inicializar()
        {
            if (InterceptarSalida)
            {
                Console.SetOut(writer);
            }
        }

        protected override void Agregar(RegistroInLineTO registro)
        {
            string salida = Formatear(registro);

            ConsoleColor colorTexto = ConsoleColor.White;
            ConsoleColor colorFondo = ConsoleColor.Black;

            if (NivelesSeguimiento != null)
            {
                ConsoleTypeTag tipo = null;

                if(registro.Tipo == Tipo.Mensaje)
                {
                    tipo = NivelesSeguimiento.FirstOrDefault(c => c.Nombre == Tipo.Mensaje && c.Nivel != null && c.Nivel == registro.Nivel);

                    if (tipo == null)
                    {
                        tipo = NivelesSeguimiento.FirstOrDefault(c => c.Nombre == Tipo.Mensaje && c._Nivel == "*");
                    }
                }
                
                if (tipo == null)
                {
                    tipo = NivelesSeguimiento.FirstOrDefault(c => c._Nombre.Equals("*", StringComparison.InvariantCultureIgnoreCase));
                }
                
                if (tipo != null)
                {
                    if (!string.IsNullOrEmpty(tipo.ColorTexto))
                    {
                        colorTexto = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), tipo.ColorTexto);
                    }

                    if (!string.IsNullOrEmpty(tipo.ColorFondo))
                    {
                        colorFondo = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), tipo.ColorFondo);
                    }
                }
            }

            Print(salida, colorFondo, colorTexto);
        }

        public static void Print(string mensaje, ConsoleColor colorFondo = ConsoleColor.Black, ConsoleColor colorTexto = ConsoleColor.White)
        {
            Console.BackgroundColor = colorFondo;
            Console.ForegroundColor = colorTexto;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public override void AgregarParametros()
        {
            Print(FormatoSalida);
            Print(SeparadorSalida.ToString());
        }
    }
}
