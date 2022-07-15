namespace Aula.AWS.Lib.Models
{
    public class ModelBase
    {
        public int id {get; private set;}
        public ModelBase(int id)
        {
            SetId(id);
        }
        public void SetId(int id)
        {
            
        }
    }
}