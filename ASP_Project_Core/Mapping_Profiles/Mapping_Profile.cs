using ASP_Project_Core.DTO_s;
using ASP_Project_Core.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.Mapping_Profiles
{
    public class Mapping_Profile
    {

        public static readonly TypeAdapterConfig _Config = new TypeAdapterConfig();
        static Mapping_Profile()
        {
            _Config.NewConfig<Items, ItemDto>()
                .Map(des => des.ItemUnits, src => src.ItemsUnits.Select(unit => unit.Units.Name).ToList())
                .Map(des => des.Stores, src => src.InvItemStore.Select(store => store.Stores.Name).ToList());
        
        }
        public static TypeAdapterConfig Config => _Config;
    }
}
