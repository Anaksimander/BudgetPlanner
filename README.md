# Тестовое задание
## Задача
### Разработать и протестировать приложение для Windows 10 с использованием среды  разработки Visual Studio.

## Описание
### Приложение для Windows c использованием UWP, представляющее из себя планировщик бюджета.

## Функционал приложения:
+ Добавление операций: доход/расход.
+ Просмотр истории операций и итоговой суммы на счете.
+ Запись операций в базу данных.
  
## Каждая операция имеет:
+ Тип операции (доход/расход).
+ Сумма операции.
+ Категория:
    + Для расходов: развлечения, еда, транспорт и т.п.
    + Для доходов: заработная плата, возврат долга, дивиденды и т.п.
+ Комментарий.

## Необязательный функционал:
+ Редактирование уже записанных операций.

## Server
+ В качестве базы данных используется Sqlite. При использовании локальной бд в виде файла при любой бд выскакивает ошибка снизу.
  
Если ошибка при записи, то нет прав на запись в Operations.db.
Скорее всего эта ошибка будет, так как при первом запуске проекта, в BudgetPlanner\BudgetPlanner\bin\x86\Debug\AppX создается копия Operations.db в котором устанавливаются права доступа пользователям только на чтение. Следовательно нужно изменить права в свойствах (долго же до меня доходило).
![](https://github.com/Anaksimander/BudgetPlanner/blob/master/BudgetPlanner/PresentProject/5.PNG?raw=true)


## Изменение доступа
### Если вы уже запустили приложение, тогда по пути по пути BudgetPlanner\BudgetPlanner\bin\x86\Debug\AppX открываем открываем свойство Operations.db

![](https://github.com/Anaksimander/BudgetPlanner/blob/master/BudgetPlanner/PresentProject/6.PNG?raw=true)

### Жмем дополнительно 

![](https://github.com/Anaksimander/BudgetPlanner/blob/master/BudgetPlanner/PresentProject/7.PNG?raw=true)

### Отключаем наследование без удаления 
![](https://github.com/Anaksimander/BudgetPlanner/blob/master/BudgetPlanner/PresentProject/8.PNG?raw=true)

### И изменяем доступ у пользователей. Я изменил доступ только у двух неизвестных учетных записей. Но можно изменить у всех. 

![](https://github.com/Anaksimander/BudgetPlanner/blob/master/BudgetPlanner/PresentProject/9.PNG?raw=true)

## Недостатки и трудности 
Как по мне недостатоков очень много, так как это мой первый проект на UWP:
+ Первое что хочется отметить - не удалось полностью следоватеть MVVM.
+ Не думаю что использование converter это правильное решение.
+ Ограничения на ввод в строки также можно было сделать по патерну а не обработчиками, но увы не хватило времени и знаний
+ Так же класс базы можно было реализовать куда лучше. Как минимум сделать его универсальным и использовать PARAMETRS для команд.
+ Не удалось в полной мере сделать визуально адпативным.
+ и т.д. 

# Фото проекта
![](https://github.com/Anaksimander/BudgetPlanner/blob/master/BudgetPlanner/PresentProject/1.png?raw=true)

![](https://github.com/Anaksimander/BudgetPlanner/blob/master/BudgetPlanner/PresentProject/2.png?raw=true)

![](https://github.com/Anaksimander/BudgetPlanner/blob/master/BudgetPlanner/PresentProject/3.png?raw=true)

![](https://github.com/Anaksimander/BudgetPlanner/blob/master/BudgetPlanner/PresentProject/4.png?raw=true)
