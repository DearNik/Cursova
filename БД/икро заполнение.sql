﻿use ResearchPapers

INSERT INTO Users 
VALUES (1,'admin','admin',NULL,1),
(2,'anton','123','antonio24@gmail',0),
(3,'chop','qwe','stint65@gmail',0),
(4,'natalia','password1','natalia@email.com',0),
(5,'ivan','password2','ivan@email.com',0),
(6,'maria','password3','maria@email.com',0),
(7,'sergey','password4','sergey@email.com',0),
(8,'olga','password5','olga@email.com',0),
(9,'dmitry','password6','dmitry@email.com',0),
(10,'elena','password7','elena@email.com',0),
(11,'vladimir','password8','vladimir@email.com',0),
(12,'irina','password9','irina@email.com',0),
(13,'alex','password10','alex@email.com',0);

INSERT INTO Scientists 
VALUES 
(1,'Антон','Перекопайко',2,'Вчитель','Багато років пряцує вчителем','Перше місце на всесвітній олімпіаді'),
(2,'Олександр','Девтяків',3,'Науковий діяч','Один з основних науковців у свері досліджень','Друге місце на всесвітній олімпіаді'),
(3,'Наталія','Іванова',4,'Вчений','Доктор наук у галузі біології','Переможець премії ім. Шевченка'),
(4,'Іван','Петров',5,'Дослідник','Спеціаліст у галузі фізики','Автор понад 50 наукових статей'),
(5,'Марія','Сидорова',6,'Хімік','Займається розробкою нових матеріалів','Має патент на синтез нового полімеру'),
(6,'Сергій','Смирнов',7,'Генетик','Вивчає генетичні механізми виникнення хвороб','Опублікував працю в провідному журналі Nature'),
(7,'Ольга','Коваленко',8,'Астроном','Дослідження в області космічної геології','Керівник численних міжнародних космічних проектів'),
(8,'Дмитро','Ігнатьєв',9,'Еколог','Активний учасник екологічних програм','Має нагороду за внесок в охорону довкілля'),
(9,'Олена','Михайлова',10,'Соціолог','Вивчає соціальні трансформації в українському суспільстві','Провів аналіз громадської думки'),
(10,'Володимир','Соколов',11,'Філософ','Розробка нового методу аналізу філософських течій','Автор книги "Сучасні тенденції у світовій філософії"'),
(11,'Ірина','Литвин',12,'Історик','Вивчення подій середньовіччя в Україні','Археологічні розкопки ведуться під її керівництвом'),
(12,'Олександр','Максимов',13,'Біоінформатик','Розробка нових методів обробки біологічних даних','Участь у глобальних біоінформатичних проектах');

INSERT INTO ResearchPapers 
VALUES 
(1,'Регіональна економіка та управління', 2, 'Макроекономічний вплив споживання енергії у трансформаційних економіках', 'На сьогоднішній день зміна клімату стала однією з найбільших екологічних проблем, яка може завдати величезних збитків суспільству та економіці, якщо не буде вжито належних заходів. Оскільки зусилля Рамкової конвенції ООН про зміну клімату (РКЗК ООН), Кіотського протоколу та інших ініціатив виявилися недостатніми для вирішення цієї проблеми, необхідно розробити інші заходи для покращення ситуації, такі як розширення використання екологічно стійких технологій, сприяння підвищенню енергоефективності або політики енергозбереження. Ця стаття присвячена макроекономічним ефектам використання енергії для девяти країн Центральної та Східної Європи і чотирьох країн колишнього Радянського Союзу, що дозволяє виділити напрямки стимулювання економічного зростання за рахунок розвитку відновлюваних джерел енергії. Мета статті - провести аналіз сучасних стратегій сталого економічного зростання відповідно до використання природних ресурсів, яке можна вважати одним з найважливіших аспектів традиційної моделі економічного зростання. Результати. Результати регресійного аналізу демонструють, що існує позитивна кореляція між зростанням ВВП та споживанням викопного палива в шести з девяти країн Центральної та Східної Європи. Серед країн колишнього Радянського Союзу сильний звязок між економічним зростанням та споживанням енергії спостерігається в Україні та Росії (меншою мірою). Натомість збільшення енергоспоживання асоціюється з нижчими темпами зростання ВВП у Білорусі та Казахстані. Позитивна кореляція між зростанням ВВП та енергоспоживанням, отримана для більшості країн, вимагає подальшого дослідження механізмів, що лежать в основі такого звязку.', GETDATE(), GETDATE()),
(2,'АКАДЕМІЧНІ ВИДАННЯ УКРАЇНИ В ІНТЕРНЕТ-ПРОСТОРІ:РЕАЛІЇ І ПЕРСПЕКТИВИ', 3, 'У статті подано світові тенденції в представленні наукової інформації, моделі організації відкритого доступу до результатів наукової діяльності', 'Наукові видання є вагомою складовою національних документальноінформаційних ресурсів. Основна соціальна функція цих видань полягає у забезпеченні первинною науковою інформацією суспільства та
ознайомленні громадян зі змістом наукової спадщини, одночасно, як
матеріальна форма руху наукового знання, вони виконують соціально важливу функцію фіксації наукових пріоритетів і виступають засобом наукових комунікацій. Тому цілком закономірно, що і на початку
ХХІ ст. науковій книзі, у найширшому розумінні терміна, було приділено значну увагу як у книгознавчих і бібліотекознавчих дослідженнях,
так і в дослідженнях академічного наукового книговидання.
Певний час дослідниками лише окреслювалися майбутні перспективи
функціонування наукових видань в електронній формі – в аспекті розвитку наукових електронних бібліотек, їх наповнення як сучасними виданнями, так і електронними копіями «золотого фонду» наукової думки
, електронної видавничої діяльності, кооперації
бібліотек і видавництв та спільної організації робіт зі створення електронних колекцій в інтересах учених . Накопичений досвід, розвиток електронних ресурсів у глобальному світі, інтеграційні процеси в освіті і науці поставили на часі питання представлення електронних журналів у системі інформаційних ресурсів бібліотек
, проведення аналізу проектів наукових видань в інтернет-просторі й
перспектив їх розвитку.

Почалось активне обговорення цих питань на міжнародних заходах. Вже в червні 2008 р. під час роботи російсько-українського форуму
«Книжкова культура: особливості становлення та розвитку» (Київ) ми
розглядали основні проекти представлення наукових видань в електронних мережах , а в грудні того ж року на Міжнародній конференції
«Книжкова культура: досвід минулого і проблеми сучасності» 
були проаналізовані фактори і тенденції їх розвитку .
Для визначення оптимальних шляхів і перспектив представлення наукових видань саме в електронному середовищі слід враховувати такі
фактори: світові тенденції представлення наукової інформації, зокрема
і міждержавні ініціативи; поява «відкритих архівів» як альтернативна
модель наукової комунікації; врахування потреб нового покоління користувачів; рівень державної підтримки книговидавничого та науковоінформаційного напрямів діяльності тощо', GETDATE(), GETDATE()),
(3,'Проаналізовано аспекти динаміки розвитку форм організації інформації', 4, 'уніфікація, згортання, розгортання, інформація, веб-середовище.', 'Розвиток знань завжди супроводжується розвитком способів передачі
цих знань. Це виражається в еволюції форм закріплення, систематизації
та представлення цих знань. Від перших способів закріплення інформації до сьогочасних змінилася не одна епоха розвитку людства. Звичайно піддалася кардинальним змінам форма, що символізує результат обробки інформаційних даних. Сьогодні ми можемо говорити про можливість роботи з інформаційними даними у веб-орієнтованому просторі.
Інтернет-технології дають можливість працювати з електронними документами, специфічно обробляючи їх та формуючи з них нові інформаційні дані. Навіть у межах веб-простору форми організації інформації
постійно змінюються, еволюціонуючи відповідно до загальної динаміки знань. Константним залишилося тільки розуміння значення способів
уніфікації інформації в межах певної форми та роль змістовності інформаційних даних у проведенні вищезазначеного процесу. Адже зміст інформації не завжди залежить від складу інформаційного повідомлення.
Саме змістовна складова відповідає за інформативність того чи іншого документа, враховуючи можливість аспектного передавання даних.', GETDATE(), GETDATE()),
(4,'Хімічні нововведення в промисловості', 5, 'Розвиток нових методів синтезу хімічних речовин для промислового використання', 'Содержание дослідження 4', GETDATE(), GETDATE()),
(5,'Генетичні детермінанти хвороб', 6, 'Розкриття генетичних механізмів, визначаючих виникнення певних захворювань', 'Содержание дослідження 5', GETDATE(), GETDATE()),
(6,'Космічна геологія і дослідження планет', 7, 'Дослідження геологічних процесів на поверхні планет системи Сонця', 'Содержание дослідження 6', GETDATE(), GETDATE()),
(7,'Екологічні аспекти рекреації', 8, 'Аналіз впливу туризму на природне середовище та рекомендації для його збереження', 'Содержание дослідження 7', GETDATE(), GETDATE()),
(8,'Соціальні трансформації в українському суспільстві', 9, 'Вивчення змін в структурі та цінностях суспільства в сучасній Україні', 'Содержание дослідження 8', GETDATE(), GETDATE()),
(9,'Філософські аспекти розвитку технологій', 10, 'Аналіз впливу технологічного розвитку на філософію та етику', 'Содержание дослідження 9', GETDATE(), GETDATE()),
(10,'Історія середньовіччя в Україні', 11, 'Дослідження ключових подій та особливостей середньовічної історії України', 'Содержание дослідження 10', GETDATE(), GETDATE()),
(11,'Біоінформатика та перспективи розвитку', 12, 'Аналіз сучасного стану та перспективи розвитку біоінформатики', 'Содержание дослідження 11', GETDATE(), GETDATE()),
(12,'Сучасні тенденції у світовій філософії', 13, 'Розгляд сучасних філософських течій та їх вплив на сучасне суспільство', 'Содержание дослідження 12', GETDATE(), GETDATE()),
(13,'Екологічні технології у сільському господарстві', 6, 'Застосування екологічно чистих технологій в агросекторі', 'Содержание дослідження 13', GETDATE(), GETDATE()),
(14,'Енергоефективність в будівництві', 7, 'Впровадження енергоефективних технологій в будівництві', 'Содержание дослідження 14', GETDATE(), GETDATE()),
(15,'Співвідношення соціальної відповідальності бізнесу та прибутковості', 8, 'Аналіз впливу соціальної відповідальності на фінансові показники підприємств', 'Содержание дослідження 15', GETDATE(), GETDATE()),
(16,'Розвиток технологій штучного інтелекту', 9, 'Прогноз розвитку технологій штучного інтелекту та їх вплив на суспільство', 'Содержание дослідження 16', GETDATE(), GETDATE()),
(17,'Гендерні аспекти ринкових відносин', 10, 'Вивчення ролі гендеру у формуванні ринкових відносин', 'Содержание дослідження 17', GETDATE(), GETDATE()),
(18,'Міжнародна політика в умовах глобалізації', 11, 'Аналіз впливу глобалізації на міжнародні відносини та політику', 'Содержание дослідження 18', GETDATE(), GETDATE()),
(19,'Історія розвитку технологій інформаційної безпеки', 2, 'Вивчення етапів та досягнень у розвитку інформаційної безпеки', 'В умовах здобуття Україною незалежності та проголошення і
впровадження курсу на демократичні, гуманістичні ідеї й цінності, проблематика розбудови та
впровадження інформаційної безпеки набуває все більшої гостроти та актуальності. Водночас, сучасний світ
наповнений багатогранними аспектами та ознаками, які характеризують інформаційну безпеку у
динамічному вимірі, який виходить далеко за межі доктринальних уявлень про зазначену дефініцію,
зокрема в контексті становлення глобального інформаційного суспільства.
Початок третього тисячоліття ознаменовано народженням суспільства нового типу −
інформаційного, в якому основним стратегічним ресурсом постає інформація. Вплив, який чинять
інформаційні процеси на всі сфери державного та суспільного життя, актуалізує найважливіші питання
соціального буття, в тому числі питання інформаційних взаємодій, включаючи боротьбу за інформаційний
простір і протидія різного роду інформаційним загрозам. У звязку з цим, не може не змінюватися ситуація
щодо дослідження ціннісної орієнтації особистості, її інформаційного обґрунтування та інформаційної
безпеки.
Роль інформаційної сфери, яка представляє собою сукупність інформації, інформаційної
інфраструктури субєктів, які здійснюють збір, формування, поширення і використання інформації, а також
систем регулювання виникаючих при цьому громадських відносин, значно зросла на сучасному етапі
розвитку суспільства. Будучи важливим фактором життя суспільства, інформаційна сфера має суттєвий
вплив на стан політичної, оборонної та економічної складових безпеки України. Від забезпечення
інформаційної безпеки істотно залежить національна безпека України, і ця залежність буде значно зростати
в ході технічного прогресу і проникнення інформаційних технологій в усі сфери діяльності сучасного
суспільства.', GETDATE(), GETDATE()),
(20,'Молекулярна біологія і її застосування в медицині', 2, 'Дослідження молекулярних механізмів хвороб та розробка нових методів лікування', 'Содержание дослідження 20', GETDATE(), GETDATE()),
(21,'Технології штучного виробництва органів', 3, 'Розробка методів штучного виробництва та трансплантації органів', 'Содержание дослідження 21', GETDATE(), GETDATE()),
(22,'Ефективність сучасних методів навчання', 4, 'Аналіз ефективності нових методів навчання та їх вплив на освітню систему', 'Содержание дослідження 22', GETDATE(), GETDATE()),
(23,'Роль сучасної медіцини в подоланні пандемій', 5, 'Аналіз внеску медичної науки у боротьбу з пандеміями та пошук нових методів профілактики', 'Содержание дослідження 23', GETDATE(), GETDATE());