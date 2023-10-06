namespace JWT_Escola.Models
{
    public class UsuarioBDFake
    {
        public static List<UsuarioEscola> UsuariosBD = new List<UsuarioEscola>
        {
            new UsuarioEscola()
            {
                Username = "jãoDaSilva",
                Password = "lalateste",
                Name = "João",
                Surname = "da Silva",
                MobilePhone = "4799999999",
                DateOfBirth = "16/12/1993",
                EmailAdress = "jãoDaSilva@gmail.com",
                Gender = "Masculino",
                Role = "Diretor"                
            },
            new UsuarioEscola()
            {
                Username = "profLuci",
                Password = "luluteste",
                Name = "Luci",
                Surname = "de Oliveira",
                MobilePhone = "4799999999",
                DateOfBirth = "16/12/1983",
                EmailAdress = "luciprof@gmail.com",
                Gender = "Feminino",
                Role = "Professor"                
            },
            new UsuarioEscola()
            {
                Username = "zekinha2023",
                Password = "zekkteste",
                Name = "Zé",
                Surname = "da Silva",
                MobilePhone = "4799999999",
                DateOfBirth = "16/10/2000",
                EmailAdress = "zezezloko@gmail.com",
                Gender = "Masculino",
                Role = "Aluno"                
            }
        };
    }
}
