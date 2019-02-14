namespace Cachet.NET.Example
{
    using System;
    using System.Linq;

    internal class Program
    {

        static string Url = "http://18.194.53.184/api/v1/";
        static string apiKey ="WvR72MkWqxSfIEsiiUqo";

        //static string Url = "https://demo.cachethq.io/api/v1/";
        //static string apiKey = "9yMHsdioQosnyVK4iCVR";

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        internal static void Main()
        {
            var Cachet = new Cachet(Url, apiKey);

            Console.WriteLine("Ping : " + Cachet.Ping() + ".");

            var Version = Cachet.GetVersion();

            Console.WriteLine("Version : " + Version.Meta   .Latest.Tag_name);


            Console.WriteLine("Components : ");
            var c1 = Cachet.ExistsComponent(int.MinValue);

            var newComp = Cachet.NewComponent("New component " + DateTime.Now.ToString(), "New testing component descr" + new string('a',70000),
                Responses.Objects.ComponentStatus.Operational, "");

            var Compo = Cachet.GetComponents();

            foreach (var Component in Compo.Data)
            {
                Console.WriteLine(" - " + Component.Name);

                if (Component.Tags.Count() == 1)
                {
                    Console.WriteLine(" -- Tags : " + Component.Tags.First());
                }
                else
                {
                    Console.WriteLine(" -- Tags : ");

                    foreach (var Tag in Component.Tags)
                    {
                        Console.WriteLine(" --- " + Tag + ".");
                    }
                }

                Console.WriteLine();
            }
            Console.WriteLine("Deleting test component: " + Cachet.DeleteComponent(newComp.Id).ToString());

            var CompoGr = Cachet.GetComponentGroups();

            Console.WriteLine("Groups : ");

            foreach (var Group in CompoGr.Data)
            {
                Console.WriteLine(" - " + Group.Name);
            }
            Console.WriteLine();

            var incidents = Cachet.GetIncidents();

            Console.WriteLine("Incidents : ");

            foreach (var incident in incidents.Data)
            {
                Console.WriteLine(" - " + incident.Name);
            }



            var metrics = Cachet.GetMetrics();

            Console.WriteLine("Metrics : ");

            foreach (var m in metrics.Data)
            {
                Console.WriteLine(" - " + m.Name);
            }

            Console.ReadKey(false);
        }
    }
}
