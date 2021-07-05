using Shared.Entities;
using Shared.Entities.JSONEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.BLL.SubFunctions
{
    public class FillInNodes
    {
        public static void FillInNodeData(TransportPathway pathway, List<Section> instructions, string EndAdress)
        {
            var LastIndex = instructions.Last();
            foreach (var instruction in instructions)
            {
                TransportNode node = new TransportNode();

                if (!(instruction.Type == "transit"))
                {
                    if (instruction.Type == "pedestrian")
                    {
                        //Console.WriteLine("Lopend");
                        node.TransportData = "Lopend";
                    }
                }
                if (instruction.Transport.Category == "Train")
                {
                    //Console.WriteLine("Trein " + instruction.Transport.Name);
                    node.TransportData = ("Trein " + instruction.Transport.Name);
                }
                if (instruction.Transport.Category == "Bus")
                {
                    //Console.WriteLine(instruction.Transport.Category + " " + instruction.Transport.Name);
                    node.TransportData = (instruction.Transport.Category + " " + instruction.Transport.Name);
                }
                if (instruction.Transport.Category != "Bus" && instruction.Type != "pedestrian")
                {
                    node.TransportData = ("Trein " + instruction.Transport.Name);
                }
                //Console.WriteLine(instruction.Arrival.Place.Name);
                node.PlaceAndTime = instruction.Arrival.Place.Name;
                //Console.WriteLine(instruction.Arrival.Time);
                if (instruction.Equals(LastIndex))
                {
                    node.PlaceAndTime = EndAdress;
                }
                node.PlaceAndTime = (node.PlaceAndTime + " | " + instruction.Arrival.Time);

                pathway.Path.Add(node);


            }
        }
    }
}
