using Backend.Controllers;
namespace Backend.Services
{
    //implementar la interfaz con su metodo
    public class PeopleService:IPeopleService
    {  
        //el punto es implementar la validacion aqui y solo utilizarla en cualquier controlador
        public bool Validate(People people) {
            if( string.IsNullOrEmpty(people.Name)|| people.Name.Length>100) 
            {
                return false; 
            }
            return true;
            
        }
    }
}
