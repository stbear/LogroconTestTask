# LogroconTestTask
Тестовое задание в Логрокон
Сделал на .Net Core, EF, PostgreSQL
Для запуска в appsettings.json прописать ConnectionString
База создаётся и наполняется из кода, доп. действий совершать не нужно. Поскольку в задании явно сказано "наполнение реализовать скриптом", приложил ещё и скрипт.

Описание методов:
- GET /goods -- список товаров
- PUT /order -- добавление пустого заказа, параметр { ClientNumber, Description }
- GET /client/{id} -- список заказов клиента
- GET /order/{id} -- детализация заказа
- POST /order -- редактирование заказа, параметр { OrderNumber, GoodNumber, Quantity }
при Quantity = 0 удаляются, при отсутствии добавляются, при наличии - редактируются

Что навскидку можно доработать:
- кэш списка товаров
- причесать статус коды (хотя по дефолту они вроде норм)
- ETag (кто первый, того и тапки)
- логирование
- юнит-тесты на редактирование заказа напрашиваются
