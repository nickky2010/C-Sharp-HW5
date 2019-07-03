# C# - Home work 5
***
#### Task 1. 


Создать класс `«Одномерный массив»`, в котором описать следующие элементы: 

* закрытое поле – массив целых чисел, 
* свойство для определения длины массива,
* индексатор для доступа к элементам поля-массива,  
* конструктор с параметрами,
* метод `ToString()`, 
* статический метод с переменным числом параметров для вычисления общей суммы отрицательных элементов в нескольких массивах, 
* операции  умножения массива на целое число и числа на массив,
* унарная операция - (знаки элементов меняются на противоположные)
* операция неявного преобразования строки в объект этого класса (Например, строка вида `«1 2 -4 3 -2»` преобразуется в объект класса Одномерный массив с полем-массивом `(1 2 -4 3 -2)`).  

При попытке неявного преобразования строки неправильного формата должно генерироваться исключение.

Разработать программу, выполняющую следующие действия:
* Ввод и вывод трех массивов `A`, `В` и `С`;
* Вычисление общей суммы отрицательных элементов в массивах `5*A` и `С`;
* Вычисление общей суммы отрицательных элементов в массивах `2*В`, `-А` и `С*4`;
* Если сумма отрицательных элементов в `массиве –А` больше суммы отрицательных элементов в `массиве А`, заменить все отрицательные повторяющиеся элементы этого массива на значение этой суммы.


***
#### Task 2. 

Разработать базовый класс, определяющий покупку товара:

#### Поля:
* название товара;
* цена в рублях;
* кол-во единиц товара;

#### Конструкторы:
* по умолчанию;
* с параметрами;

#### Методы:
* установки/считывания полей (можно использовать свойства, в т.ч. автоматические);
* `GetCost()` – вычисляет стоимость покупки;
* `ToString()` – переводит объект в строку с разделителями «;»;
* `Equals()` – сравнивает две продажи (считаются равными, если совпадают название и цена).

Разработать *первый производный класс*, для покупки товара с фиксированной скидкой от цены и переопределить нужные методы (`GetCost()` и `ToString()`).

Разработать *второй производный класс* (от базового) со скидкой к цене, если количество единиц товара не меньше некоторой константы подкласса. Переопределить нужные методы.

***

#### Разработать консольное приложение, выполняющее следующее:
1. Создать массив из шести объектов (2 – базового класса, по 2 – каждого производного класса).
2. Вывести массив на консоль.
3. Найти покупку с максимальной стоимостью и вывести эту покупку после цикла.
4. Определить, являются ли все покупки равными (да/нет).
5. Задачи 2–4 реализовать в одном общем цикле.
