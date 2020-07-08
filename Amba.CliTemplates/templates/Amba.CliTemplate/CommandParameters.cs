using AutoMapper;

namespace Amba.CliTemplate
{
    class CommandParameters
    {
        public string Name { get; set; }
        public string Language { get; set; } = "english";
    }

    public class CommandParametersProfile : Profile
    {
        public CommandParametersProfile()
        {
            CreateMap<Program, CommandParameters>();
        }
    }
}