using System;
using TweetSharp;
using System.Timers;
using System.Net;
using System.Reactive;
using System.Threading;

namespace TwitterBOT
{
    class Program
    {
        public static System.Timers.Timer _timer;
        private static string costumer_key = "XXX";
        private static string costumer_key_secret = "X";
        private static string access_token = "X";
        private static string access_token_secret = "X";
        private static TwitterService service = new TwitterService(
            costumer_key,
            costumer_key_secret,
            access_token,
            access_token_secret);

        public static string[] frases = {
            "Quanto mais eu treino, mais sorte eu tenho.",
            "Controle o seu destino ou alguém controlará.",
            "Para ter um negócio de sucesso, alguém, algum dia, teve que tomar uma atitude de coragem.",
            "Um bom chefe faz com que homens comuns façam coisas incomuns.",
            "Não sou especialista em Brasil, mas uma coisa estou habilitado a dizer: Não creiam que mão-de-obra barata ainda seja uma vantagem.",
            "Como gerente você é pago para estar desconfortável. Se você está confortável, é um sinal seguro de que você está fazendo as coisas erradas.",
            "Pessoas que não se arriscam geralmente cometem dois grandes erros por ano. Pessoas que se arriscam normalmente cometem dois grandes erros por ano.",
            "Trocava toda a minha tecnologia por uma tarde com Sócrates.",
            "Se tu o desejas, podes voar, só tens de confiar muito em ti.",
            "Design é função, não forma.",
            "Às vezes, a vida vai te acertar um tijolo na cabeça. Não perca a fé.",
            "Para mim, não há nada mais importante no futuro que o desenho. É a alma de tudo o que é criado pelo homem.",
            "Você pode encarar um erro como uma besteira a ser esquecida ou como um resultado que aponta uma nova direção.",
            "Passo a passo. Não consigo pensar em nenhum outro modo de se realizar algo.",
            "Gerenciamento é substituir músculos por pensamentos, folclore e superstição por conhecimento, e força por cooperação.",
            "Existe o risco que você não pode jamais correr, e existe o risco que você não pode deixar de correr.",
            "As únicas coisas que evoluem por vontade própria em uma organização são a desordem, o atrito e o mau desempenho.",
            "Não há nada tão inútil quanto fazer eficientemente o que não deveria ser feito.",
            "Os milagres acontecem às vezes, mas é preciso trabalhar tremendamente para que aconteçam.",
            "A simplicidade tende ao desenvolvimento, a complexidade à desintegração",
            "Não podemos prever o futuro, mas podemos criá-lo.",
            "O conhecimento e a informação são os recursos estratégicos para o desenvolvimento de qualquer país. Os portadores desses recursos são as pessoas.",
            "Não deixe o barulho da opinião dos outros abafar sua voz interior. E mais importante, tenha a coragem de seguir seu coração e sua intuição. Eles de alguma forma já sabem o que você realmente quer se tornar. Tudo o mais é secundário.",
            "Na maioria dos casos, forças e fraquezas são dois lados da mesma moeda. Uma força em uma situação é uma fraqueza em outra, mas frequentemente as pessoas não conseguem trocar as marchas. É uma coisa muito sutil falar sobre forças e fraquezas porque elas sempre são a mesma coisa.",
            "Não faz sentido olhar para trás e pensar: devia ter feito isso ou aquilo, devia ter estado lá. Isso não importa. Vamos inventar o amanhã e parar de nos preocupar com o passado.",
            "Se hoje fosse o último dia da minha vida, eu desejaria fazer o que estou prestes a fazer hoje? E se a resposta for Não por muitos dias seguidos, eu sei que preciso mudar alguma coisa.",
            "Cada sonho que você deixa pra trás, é um pedaço do seu futuro que deixa de existir.",
            "Algumas pessoas acham que foco significa dizer sim para a coisa em que você irá se focar. Mas não é nada disso. Significa dizer não às centenas de outras boas idéias que existem. Você precisa selecionar cuidadosamente.",
            "As pessoas não sabem o que querem, até mostrarmos a elas.",
            "Ser o mais rico do cemitério não é o que mais importa para mim…Ir para a cama à noite e pensar que foi feito alguma coisa grande. Isso é o que mais importa para mim.",
            "Foco é dizer não.",
            "Para se ter sucesso, é necessário amar de verdade o que se faz. Caso contrário, levando em conta apenas o lado racional, você simplesmente desiste. É o que acontece com a maioria das pessoas.",
            "Concentre-se naquilo que você é bom, delegue todo o resto.",
            "As pessoas ligam a televisão quando querem desligar o cérebro.",
            "Melhor ser pirata, do que marinheiro...",
            "Seu trabalho vai preencher uma parte grande da sua vida, e a única maneira de ficar realmente satisfeito é fazer o que você acredita ser um ótimo trabalho. E a única maneira de fazer um excelente trabalho é amar o que você faz.",
            "Se você viver cada dia de sua vida como se fosse o último, um dia você estará certo.",
            "Seja um padrão de qualidade. As pessoas não estão acostumadas a um ambiente onde o melhor é o esperado.",
            "Lembrar que você vai morrer é a melhor maneira que eu conheço para evitar a armadilha de pensar que você tem algo a perder. Você está nú. Não há razão para não seguir seu coração.",
            "Seu tempo é limitado, Então não fique vivendo a vida dos outros.",
            "Não deixe que o ruído da opinião alheia impeça que você escute a sua voz interior.",
            "Se você faz algo de bom e tudo dá certo, acho que é hora de pensar em outra coisa e tentar adivinhar o que vem pela frente.",
            "A maior invenção do mundo não é a minha tecnologia! É a morte! pois através dela, o velho sempre dará lugar para o novo!",
            "Parece que você está apenas à procura de alguém para ficar zangado em vez de si próprio.",
            "Não penso muito em legado para as próximas gerações. Penso apenas em acordar de manhã e trabalhar com pessoas brilhantes para criar coisas que, espero, sejam tão apreciadas por outras pessoas como são apreciadas por nós.",
            "Nascemos, vivemos por um momento breve e morremos. Tem sido assim há muito tempo. A tecnologia não está mudando muito este cenário.",
            "Basicamente você assiste TV pra desligar seu cérebro, e usa o computador quando você o quer de volta!",
            "A não ser que o identificador de chamada diga que é Deus ligando, você não deve atender ao telefone durante a missa.",
            "Você tem que encontrar o que você ama!",
            "Quando você faz em fração de segundo o que os outros levariam horas para fazer, tudo parece mágica.",
            "Computadores são como bicicletas para nossas mentes.",
            "Maestros não sabem como o oboé faz o seu trabalho, mas eles sabem com o que o oboé deve contribuir.",
            "Eu valia pouco mais que um milhão de dólares quando tinha 23 anos e mais de 100 milhões de dólares quando tinha 25, e nada disso era muito importante, porque nunca fiz as coisas pelo dinheiro.",
            "Eu sempre disse que se alguma vez chegasse o momento em que eu não pudesse mais cumprir minhas obrigações e expectativas como CEO da Apple, eu seria o primeiro a saber. Infelizmente, esse dia chegou.",
            "A qualidade é a nossa melhor garantia da fidelidade do cliente, a nossa mais forte defesa contra a competição estrangeira e o único caminho para o crescimento e para os lucros.",
            "Um líder não é alguém a quem foi dada uma coroa, mas a quem foi dada a responsabilidade de fazer sobressair o melhor que há nos outros.",
            "Quando o ritmo de mudança dentro da empresa for ultrapassado pelo ritmo da mudança fora dela, o fim está próximo.",
            "Os elefantes demoram a se adaptar, já as baratas sobrevivem em qualquer ambiente.",
            "Mais arriscado que mudar é continuar fazendo a mesma coisa.",
            "Existem dois tipos de riscos: Aqueles que não podemos nos dar ao luxo de correr e aqueles que não podemos nos dar ao luxo de não correr.",
            "O mais importante na comunicação é ouvir o que não foi dito."
        };

        static void Main(string[] args)
        {
            while (true)
            {
                for(int i = 0; i < frases.Length; i++)
                {
                    Console.WriteLine(DateTime.Now + " - Bot Started");
                    SentTweet(frases[i]);
                    Console.Read();
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                }
               
            }
        }

        private static void SentTweet(string _station)
        {
            service.SendTweet(new SendTweetOptions { Status = _station }, (tweet, response) =>
            {
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(DateTime.Now + "Tweet Enviado!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(DateTime.Now + "Tweet não enviado!");
                    Console.ResetColor();
                }

            });
        }
    }
}
