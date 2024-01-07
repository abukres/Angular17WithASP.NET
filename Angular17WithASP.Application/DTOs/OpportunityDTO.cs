using Angular17WithASP.Core.Entities;
using AutoMapper;

namespace Angular17WithASP.Application.DTOs
{
    public class OpportunityDTO
    {
        public string Name { get; set; }
        public string Manager { get; set; }
        public int Products { get; set; }
        public decimal Total { get; set; }
        
        private class Mapping : Profile
        {
            public Mapping()
            {
                //TODO:  create the different maps
                /*CreateMap<Opportunity, OpportunityDTO>().ForMember(d => d.Manager, 
                    opt => opt.MapFrom(s => s.xx));*/
            }
        }
    }
}
