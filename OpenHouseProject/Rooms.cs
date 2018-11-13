using System;
using System.Collections.Generic;
using System.Text;

namespace OpenHouseProject
{
    class Rooms
    {
        public string Name { get; set; }
        public Func<bool> runStory { get; set; }
        public List<string> Furniture { get; set; }
    }
}
