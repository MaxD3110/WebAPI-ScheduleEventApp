<div id="top"></div>

[![LinkedIn][linkedin-shield]][linkedin-url]
  


## CRUD Web API для работы с мероприятиями

# Инструкция по запуску

### Внимание!

Для корректной работы базы данных необходим установленный на компьютер MS SQL Server!

БД автоматически появляется на локальном сервере ((localdb)\\MSSQLLocalDB)
__________________________________________________________________________________

1. Склонировать проект в VisualStudio, запустить через IIS Express

![launch](https://user-images.githubusercontent.com/80919963/185363957-bcd1ca40-2d2e-41df-b5f0-a345f128ac0b.PNG)

2. Всё

# Инструкция по применению

1. При запуске открывается Swagger, реализована авторизация Jwt.
Для генерации ключа необходимо выполнить запрос Token

Логин: admin
Пароль: admin 

![Code](https://user-images.githubusercontent.com/80919963/185365699-7949d95d-ac0e-45e2-a053-e190b18dc427.PNG)

2. Скопировать ключ и произвести авторизацию (продолжительность жизни ключа - 20 минут)

![Copy](https://user-images.githubusercontent.com/80919963/185366038-3fcb4c62-3ec6-4c28-9b76-30e1ccb059a7.PNG)

![Authorize](https://user-images.githubusercontent.com/80919963/185366052-da407b3d-e6ee-480e-8353-9963bfcd539c.PNG)

3. Если всё выполнено верно - Вы имеете доступ к запросам Event

Реализованы операции:
* Создание нового мероприятия
* Изменение существующего
* Удаление существующего
* Вывод всех мероприятий из базы данных
* Поиск мероприятия по Id


<p align="right"><a href="#top">В начало</a></p>


<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/maxim-anisovec/
