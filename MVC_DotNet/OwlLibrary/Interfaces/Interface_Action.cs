using OwlLibrary.Classes.Models.Basic;

namespace OwlLibrary.Interfaces
{
    public interface Interface_Action<T2> where T2 : new()
    {
        int DoAction(ref Model_Query<T2> tableModel) ;
    }
}
