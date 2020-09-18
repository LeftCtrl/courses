=Тренировочное задание по созданию веб-приложения=

==Полезные ссылки, использованные при выполнении задания==

===Тестирование запросов к soap-сервису===
 
SoapUI 
1) https://www.soapui.org/ - скачать
2) https://www.youtube.com/watch?v=C2TMZeRdLKw - как использовать (в первых пяти минутах видео)
3) схема wsdl для курсов валют: https://www.cbr.ru/DailyInfoWebServ/DailyInfo.asmx?WSDL

Postman
1) https://www.postman.com/ - скачать
2) soap-запросы через постман: https://learning.postman.com/docs/sending-requests/supported-api-frameworks/making-soap-requests/

Примеры работы с cbr api из C#:
1) https://www.cbr.ru/StaticHtml/File/33109/QueryVal.zip
2) https://www.cbr.ru/StaticHtml/File/33109/WSExplorer.rar

===Геометрия===

1) Алгоритм проверки на попадание точки в круг: https://taskcode.ru/if/circle-point
2) Чтобы не терять точность при извлечении корня можно возводить обе части выражения в квадрат:
https://www.yaklass.ru/p/algebra/8-klass/neravenstva-11023/svoistva-chislovykh-neravenstv-12298/re-d8bbf93c-7994-4231-8897-e46a4eed8d03

===Net Core Web API===

1) Создание проекта - https://metanit.com/sharp/aspnet5/23.1.php
2) Версионирование API - https://www.talkingdotnet.com/support-multiple-versions-of-asp-net-core-web-api/
пока обошелся простой реализацией (указание версии в атрибуте Route контроллера вручную)

3) В проекте используются not nullable reference types - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-reference-types
подключение фичи в проект - https://stackoverflow.com/a/62116924
4) Для работы с датами без времени используется NodaTime - https://nodatime.org/#install

Почему плохо использовать DateTime для даты?
https://habr.com/ru/post/266937/ ("Primitive obsession")

4.1) Для красивого отображения данных пришлось написать сериализатор для LocalDate:
https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-converters-how-to 

как добавить свой конвертер в net core - https://stackoverflow.com/a/58392418

Формат отображения можно менять на уровне приложения, пока что задал yyyyMMdd

5) Добавляем свои сервисы в DI - https://metanit.com/sharp/aspnet5/2.19.php

6) Добавляем файл конфигурации - https://habr.com/ru/post/453416/

Применяем Options-классы в DI -  https://visualstudiomagazine.com/articles/2019/01/01/accessing-configuration-settings.aspx

7) Логгирование - https://github.com/serilog/serilog-extensions-logging-file

==TO DO==

1) Обработка ошибок
1.1) Пройтись от единственного пока метода контроллера "вниз" и расставить типизированные try/catch там, где есть ожидаемые типы ошибок
1.2) Убрать из контроллера нетипизированный try/catch (ловить любой Exception - антипаттерн)
1.3) Добавить обработчик ошибок на уровне приложения

2) Логгирование 
2.1) Посмотреть, можно ли с помощью middleware логгировать все обращения к api, без написания каждый раз этого кода в методе контроллера

3) Вывод ошибок в UI
3.1) Добавить MVC для работы с веб-страницой ошибок?
3.2) Как пробрасывать текст ошибки туда?

4) Хостинг
4.1) Первый претендент - firebase, проверить поддерживает ли он хостинг net core 3.1 и c# 8 (скорее всего да)
4.2) Посмотреть что там с хранением логов на диске / их архивированием

5) Добавить Swagger для тестирования API

==Вопросы по тех.заданию==

1. Геометрия 

1.1 Формат радиуса (целое/дробное, точность, макс.значение)
1.2 Формат координат (целое/дробное, точность, макс.значение)
1.3 Считать ли корректными координаты внутри круга лежащие на оси / в центре круга? Если да - к какой четверти их относить?

2. Определение даты

2.1 Учитывать ли часовые пояса при определении даты по четверти круга? Если да, то как именно.

3. Общение с ЦБ РФ

3.1 Формат кода валюты - трехбуквенный (USD, EUR и т.д.). Почти уверен что да, но в данных от ЦБ так же имеется полное наименование по которому тоже можно было бы искать, типа "Доллар США".
3.2 Нужно ли кешировать результаты запроса к ЦБ? Это напрашивается, т.к. они отдают больше данных за раз, чем нужно по алгоритму и эти данные редко меняются.
3.3 При запросе на завтрашнюю дату, если данных у ЦБ еще нет, вместо ошибки ЦБ присылает последние имеющиеся данные (за сегодня). В этом случае ообщать пользователю, что данных нет, или выводить то что есть? Сейчас говорю, что данных нет.

4. Параметры работы веб сервиса

4.1 Нужно ли предусмотреть алгоритм очистки/архивации логов? 
4.2 Не понятно, что имеется ввиду под "применить паттерн MVC" применительно к Web API, у него же нет View. Сервис должен быть гибридным? (Иметь и API, и представления - например страницу сообщения об ошибке)
4.3 На каком языке предпочтительнее писать комментарии в коде/к коммиту в системе контроля версий?

4.1 Должны ли параметры из конфига автоматически перечитываться при изменении? (В прошлых версиях .Net для применения изменений был необходим перезапуск приложения, сейчас можно это обойти)
