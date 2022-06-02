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
+ В качестве базы данных используется Sqlite
  
Если ошибка при записи, то нет прав на запись в Operations.db по пути BudgetPlanner\BudgetPlanner\bin\x86\Debug\AppX. Нужно изменить права в свойствах. Долго же до меня доходило.

нажать на кнопку дополнительно
![](https://github.com/Anaksimander/BudgetPlanner/blob/master/BudgetPlanner/PresentProject/5.png?raw=true)


отключить наследование без удаления 
![](https://github.com/Anaksimander/BudgetPlanner/blob/master/BudgetPlanner/PresentProject/6.png?raw=true)

и изменить досуп у пользователей - в моем случае было достаточн оизменить доступ у этих двух пользователей

![](https://github.com/Anaksimander/BudgetPlanner/blob/master/BudgetPlanner/PresentProject/8.png?raw=true)
![](https://github.com/Anaksimander/BudgetPlanner/blob/master/BudgetPlanner/PresentProject/9.png?raw=true)


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
