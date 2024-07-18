using Backend.Controllers;

namespace Backend.Services
{
    public interface IPeopleService
    {
        //especificar que un metodo validate en todos los ue implementen interfaze
        bool Validate(People people);
    }
}
