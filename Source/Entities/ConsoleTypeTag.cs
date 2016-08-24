using Ada.Framework.Development.Log4Me.Config.Entities;
using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Writers.ConsoleWrite.Entities
{
    [XmlType("ConsoleType")]
    public class ConsoleTypeTag : TypeTag
    {
        [XmlAttribute("BackgroundColor")]
        public string ColorFondo { get; set; }

        [XmlAttribute("ForegroundColor")]
        public string ColorTexto { get; set; }
    }
}
