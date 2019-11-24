using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class APISpellDictionary
    {

        List<RootSpell> spells = new List<RootSpell>();
        List<string> spellNames = new List<string>();
        List<string> spellDescriptions = new List<string>();

        public List<string> SpellNames
        {
            get { return spellNames; }
            set { spellNames = value; }
        }

        public List<string> SpellDescriptions
        {
            get { return spellDescriptions; }
            set { spellDescriptions = value; }
        }


        public APISpellDictionary()
        {
            InitializeDictionary();
        }

        public async void InitializeDictionary()
        {
            for (int i = 1; i < 319; i++)
            {
                //Initializes view of all spells in order
                Task t = Task.Run( () => JsonCall(i));
                t.Wait();
            }
        }

        public async Task JsonCall(int index)
        {
            //Retrieves a spell by index
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri($"http://dnd5eapi.co/api/spells/{index}/"));
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RootSpell>(json);
            spells.Add(result);
            spellNames.Add(result.name);
            string description = "";
            for(int i = 0; i < result.Desc.Count; i++)
            {
                description += result.Desc.ElementAt(i);
            }
            spellDescriptions.Add(description);
        }
    }
}
