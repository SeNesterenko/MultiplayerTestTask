#### Тестовое задание на позицию UnityDeveloper.

### **Билд на проект**
https://drive.google.com/file/d/1lYZ0GBh0JpHVD06PEiKFoHhmr5PDpIf-/view?usp=share_link

### **Задание:** 
+ **1. Сцены**
  + **1.1.** - Есть 3 сцены (Loading, Lobby, Game).
  + **1.2.** - Loading - первая сцена, на которотой происходит подключение к серверу.
  + **1.3.** - Lobby - вторая сцена, на которой игрок выбирает создать ли ему комнату или подключиться к уже существующей.
  + **1.3.** - Game - третья сцена, на которой происходят основные действия игры.
+ **2. Игрок**
  + **2.1.** - Перемещается с помощью джойстика.
  + **2.2.** - Стреляет на кнопку.
  + **2.3.** - Имеет: Здоровье, имя, количество собранных монет, цвет.
+ **3. Монета**
  + **3.1.** - Спавнятся на карте при заходе в комнату первого игрока.
  + **3.2.** - Количество монет на карте настраиваемое.
  + **3.3.** - Имеент настраивамую ценность на случай появления в игре разных типво монет.
+ **4. Геймлей**
  + **4.1.** - При заходе минимум двух игкроков в комнатц, появляется возможность управления. Если игрок только один, передвижение заблокировано.
  + **4.2.** - Игроки могут собирать монеты разбросанные на карте и стрелять друг в друга.
  + **4.3.** - Когда здоровье одного из игроков доходит до 0, его аватар отключается и он ждёт окончания игры.
  + **4.3.** - Когда на сцене останется 1 игрок, всплывает окно окончания игры с именем победителя и количеством собранных монет.

### **Используемые дополнительные технологии:**
  + **1.** - HFSM - для контроля состояния на сцене Game. Потенциально при расширении функционала остальных сцен, можно добавить новые состояния в стейт машину, для более удобного контроля игры.
  + **2.** - EventBus - для менее связанного общения разных модулей.
  + **3.** - PoolObjects - для того, чтобы пули не спавнились бесконечно, после попадания в игрока или если они включены больше определённого времени, пуля отключается и возвращается в пул.
  + **4.** - Photon - для сетевого взаимодействия игроков.

### **Реализация:** 
https://drive.google.com/file/d/1tgdU9URkGiaoXDHMjPxOkjWzaqUBslwX/view?usp=sharing

+ **1. Подключение к серверу:**

  + При заходе в игру и попадании на сцену Load, в качестве точки входа выступает LoadManager, которыё применяет настройки подключения и переносит игрока на сцену Lobby.

+ **2. Выбор комнаты:**
  + При попадании в Lobby, в качестве точки входа выступает LobbyManager игрок вводит свой никнейм и создаёт комнату или вводит название уже существующей. После этого игрок попадает в игру.

+ **2. Игра:**
  + При попадании в Game, в качестве точки входа выступает GameManager, он же выступает в качестве своего рода медиатора. Он значет про системы на сцене и при необходимости перекидывает данные между ними и инициализирует их.
![UML](https://user-images.githubusercontent.com/107647367/229501518-58592866-7b12-4ffa-9bf7-9c939e0781af.png)

  + PlayerModelCreatorSystem - считывает данные с конфига (в котором заданы цвета игроков и их стартовое здоровье и стартовое количество монет), знает только про конфиг.
![UML](https://user-images.githubusercontent.com/107647367/229501767-15ed2552-857b-4a09-9c06-79118ef81e40.png)

  + PlayerSpawnerSystem - создаёт представление игрока на сцене по полученной модели.
  + PlayerManagement - отвечает за управление игроком.
  + PlayerController - закидывает инормацию о событиях, которые произошли с игроком в eventBus. А так же хранит в себе модель и оружие игрока.
![UML](https://user-images.githubusercontent.com/107647367/229504105-a27c797e-48c2-470b-a3de-c814881d3abf.png)

  + CoinSpwnerSystem - отвечает за спавн монет на сцене
  ![UML](https://user-images.githubusercontent.com/107647367/229504562-5e310d9b-e4ac-458f-9758-dcdd2285919f.png)

  + PlayerIncomeSystem - отвечает за обработку события, когда игрок подобрал монетку.
  + PlayerDamageSystem - отвечает за обработку получения игроком урона.
  
  + За обработку UI элементов отвечают специальные контроллеры , которые передают во вью корректную информацию.
  + PlayerViewController - отвечает за то, чтобы передавать данные с model на view. Model и view, ничего не знаю друг о друге и не содержат логики. Если с моделью происходят какие-либо изменения, то контроллер это видит и передаёт на View.
![UML](https://user-images.githubusercontent.com/107647367/229505940-80d88d7f-c9e6-4b52-9f2c-e719ae4e0aea.png)

  + PoolSystem - отвечает за контроль пула объектов bullet, для того, что не спавнить и удалять бесконечно число объектов, а переиспользовать их контролируя включение в выключение объектов.
  + PhotonSerializationSystem - содержит методы сериалтзации кастомных типов данных для photon.
  + StateManager - контролирует состояния игры и окончания игры, при получении ивента, обрабатывает их и принимает решение, какое сейчас состояние у игры.
