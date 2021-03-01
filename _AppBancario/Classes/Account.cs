using AppBancario.Enum;

namespace AppBancario.Classes
{
    public class Account
    {
        public string name;

        private string _cpf;

        public string cpf 
        {
            get 
            {
                return _cpf;
            }
            set
            {
                _cpf = value;
            }
        }
        public AccountType Type;

        private double _money;

        public double money 
        {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
            }
        }
        
    }
}