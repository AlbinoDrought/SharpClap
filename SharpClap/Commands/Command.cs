using System;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SharpClap.Commands
{
    // must be done for serializer
    [XmlInclude(typeof(Command)), XmlInclude(typeof(PressKey)), XmlInclude(typeof(Delay))]
    [Serializable]
    public abstract class Command
    {
        // no async abstracts...
        public async virtual Task<string> Execute()
        {
            await Task.Delay(0);

            return "Finished doing absolutely nothing!";
        }
    }

    /* TO ADD NEW COMMAND:
     * Create inherited class
     * Add [XmlInclude(typeof(NewCommand))] here, or else you will get error on serialization
     * Edit DialogHelper.Edit to support NewCommand
     * Create a way to add the command to lstActions on main form */
}
