using Backend.Controllers;
namespace Backend.Services
{
    //implementar la interfaz con su metodo
    public class People2Service : IPeopleService
    {
        //el punto es implementar la validacion aqui y solo utilizarla en cualquier controlador
        public bool Validate(People people)
        {
            if (string.IsNullOrEmpty(people.Name) || people.Name.Length > 100||people.Name.Length<3)
            {
                return false;
            }
            return true;

        }
    }
}
