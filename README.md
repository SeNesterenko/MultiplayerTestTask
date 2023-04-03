#### Тестовое задание на позицию UnityDeveloper.

### **Билд на проект**
Будет тут

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
Ссылка

+ **1. Подключение к серверу:**

  При заходе в игру и попадании на сцену Load, в работу вступает LoadManager, которыё применяет настройки подключения и переносит игрока на сцену Lobby.

+ **2. Выбор комнаты:**
  При попадании в Lobby игрок вводит свой никнейм и создаёт комнату или вводит название уже существующей. После этого игрок попадает в игру.

+ **2. Игра:**
