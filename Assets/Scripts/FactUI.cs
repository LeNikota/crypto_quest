// Этот класс отвечает за отображение фактов о различных методах шифрования в пользовательском интерфейсе Unity.
// Он создает кнопки для каждого шифра и отображает соответствующий текст при нажатии на кнопку.

using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// UI and background logic is in one file (coupled together)
class Facts : MonoBehaviour
{
    [SerializeField] Transform scrollViewContentTransform; // Трансформ для содержимого прокручиваемого представления
    [SerializeField] GameObject buttonPrefab; // Префаб кнопки для создания новых кнопок
    [SerializeField] TextMeshProUGUI textDisplay; // Текстовое поле для отображения фактов

    // Словарь, содержащий названия шифров и соответствующие факты
    Dictionary<string, string> facts = new()
    {
        {"Морзе", @"
Шифр Морзе — это метод передачи текстовой информации с помощью последовательности точек и тире.
Он был разработан в 1830-х годах и широко использовался в телеграфии и радиосвязи.

Пример: 'A' = '.-', 'B' = '-...'.
        "},
        {"Цезарь", @"
Шифр Цезаря — один из самых простых и старейших методов шифрования. 
Он был назван в честь римского императора Юлия Цезаря, который использовал его для секретной переписки.
Шифр Цезаря представляет собой моноалфавитный шифр подстановки. 
Каждая буква в тексте сдвигается на фиксированное количество позиций по алфавиту. 

Например, если сдвиг равен 3, то буква 'A' становится 'D', 'B' — 'E' и так далее.
        "},
        {"Вижинер", @"
Шифр Вижинера — это метод шифрования, который использует ключевое слово для определения смещения каждой буквы в тексте.
Он был разработан Блезом Вижинером в 19 веке и считается более безопасным, чем шифр Цезаря.

Пример: для ключа 'KEY' и текста 'HELLO' шифр будет: 
'H' -> 'L', 
'E' -> 'I', 
'L' -> 'R', 
'L' -> 'P', 
'O' -> 'S'.
        "},
        {"Тритемиус", @"
Шифр Тритемиуса — это метод шифрования, который использует таблицу, состоящую из нескольких строк, 
где каждая строка представляет собой сдвинутую версию алфавита.
Он был разработан Иоганном Тритемием в 16 веке и использовался для защиты текстов.

Пример: для буквы 'A' сдвиг на 1 будет 'B', на 2 — 'C'.
        "},
        {"Вернам", @"
Шифр Вернама, также известный как одноразовый шифр, использует случайный ключ, 
который такой же длины, как и сообщение. 
Он считается абсолютно безопасным, если ключ используется только один раз и остается секретным.

Пример: 'HELLO' с ключом 'XMCKL' шифруется в 'EQNVK'.
        "},
        {"Атбаш", @"
Шифр Атбаш — это простой шифр подстановки, в котором буквы заменяются на противоположные в алфавите.
Он использовался в древнееврейских текстах и является одним из самых старых известных шифров.

Пример: 
'A' -> 'Z', 
'B' -> 'Y', 
'C' -> 'X'.
        "},
        {"Факт 1", @"
В Древнем Риме шифрование играло важную роль в передаче секретных сообщений, особенно в военной сфере. Наиболее известным методом шифрования того времени был шифр Цезаря, который использовал простую замену букв, сдвигая их на определенное количество позиций в алфавите. Этот метод был разработан и применялся самим римским полководцем Юлием Цезарем для обеспечения конфиденциальности своих сообщений.

Одним из интересных устройств, использовавшихся для шифрования, была скитала — полоса пергамента, обернутая вокруг цилиндра. Этот метод позволял передавать сообщения, которые могли быть прочитаны только теми, кто имел соответствующий цилиндр. В Древнем Риме также использовались различные методы шифрования, включая замену и перестановку букв, однако использование чисел не было распространено, как и криптоанализ, который развивался позже.

Римский писатель Цицерон в своих трудах описывал методы шифрования, подчеркивая их важность для безопасности информации. Успех шифрования в Древнем Риме зависел от нескольких факторов, включая сложность шифра, доступность материалов и уровень образования шифровальщика. Важно отметить, что Цезарь использовал шифр с заменой в своем знаменитом методе, что сделало его одним из первых известных примеров использования шифрования в истории.

Эти факты встречаются в вопросах 1-7.
        "},
        {
        "Факт 2", @"
Квантовая криптография представляет собой современный метод обеспечения безопасности передачи данных, основанный на использовании квантовых свойств частиц. Этот подход позволяет создавать системы шифрования, которые значительно превосходят классические методы по уровню безопасности.

В основе квантовой криптографии лежит несколько ключевых принципов, среди которых принцип неопределенности Гейзенберга, принцип суперпозиции и принцип запутанности. Все эти принципы играют важную роль в обеспечении надежности и безопасности квантовых систем.

Наиболее известным протоколом в области квантовой криптографии является протокол BB84, который позволяет двум сторонам безопасно обмениваться ключами. В этом контексте квантовый ключ представляет собой ключ, который невозможно скопировать без обнаружения, что делает его особенно ценным для защиты информации.

Одним из уникальных свойств квантовых частиц является изменение состояния при измерении, что позволяет обнаруживать попытки прослушивания. Важно отметить, что классическое шифрование не является частью квантовой криптографии, в отличие от таких методов, как квантовая телепортация и квантовая запутанность.

Квантовая криптография предлагает более высокий уровень безопасности по сравнению с классической благодаря применению квантовых битов (кубитов), что делает ее более устойчивой к атакам. Для передачи квантовых битов используются оптические волокна, хотя также могут применяться и другие методы, такие как радиоволны и электромагнитные поля.

Наконец, на безопасность квантовой криптографии могут влиять различные факторы, включая качество источника квантовых частиц, уровень образования пользователей и доступность технологий, что подчеркивает важность комплексного подхода к обеспечению безопасности в этой области.

Эти факты встречаются в вопросах 8-16.
        "},
        {
        "Факт 3", @"
В Древнем Египте шифрование играло важную роль в защите сообщений, и одним из методов, использовавшихся для этой цели, были иероглифы. Эти символы не только служили для записи информации, но и могли содержать зашифрованные сообщения. В иероглифах часто использовались птицы, числа и геометрические фигуры для передачи секретных сообщений, что подчеркивает разнообразие символов.

Среди древнеегипетских текстов Папирус Ринда считается одним из первых примеров использования шифрования. Для защиты информации о царских тайнах использовались различные методы, включая замену символов, перестановку символов и использование секретных иероглифов, что делает правильным ответом — все вышеперечисленное.

Успех шифрования в Древнем Египте зависел от нескольких факторов, таких как уровень образования писцов, доступность материалов для письма и сложность шифра.

Иероглифы могли использоваться в различных текстах, включая папирусы с рецептами, религиозные тексты и административные документы. Их многообразие символов, возможность создания новых символов и сложность прочтения без специальной подготовки делают иероглифы подходящими для шифрования.

Для передачи секретных сообщений в Древнем Египте использовались шифровальные таблицы, передача сообщений через курьеров и запись на папирусе с использованием иероглифов. Символ Око Гора мог означать ""секрет"" или ""тайна"", что подчеркивает его важность в контексте шифрования.

Сложность расшифровки сообщений могла быть вызвана многообразием значений одного символа, отсутствием пробелов между словами и использованием фонетических и логографических символов.

Документы, такие как договоры между фараонами, религиозные тексты и записи о налогах, могли содержать зашифрованные сообщения. Для защиты военных стратегий могли использоваться кодовые слова, запись на недоступных для врагов языках и применение иероглифов с двойным значением.

Развитие криптографии в Древнем Египте было обусловлено необходимостью защиты государственных тайн, развитием торговли и дипломатии и конфликтами с соседними государствами. Наконец, методы шифрования, такие как секретные знаки, известные только определенной группе людей, использование различных стилей письма и применение цветовых кодов, также могли использоваться для шифрования сообщений.

Эти факты встречаются в вопросах 16-30.
        "},
        {
        "Факт 4", @"
Шифр Виженера представляет собой метод шифрования, который использует ключевое слово для замены букв. Этот метод основан на принципе замены букв на основе ключевого слова, что делает его более сложным по сравнению с простыми шифрами, такими как шифр Цезаря.

Для шифрования с помощью шифра Виженера необходим ключевое слово, которое определяет, как будут заменяться буквы в исходном сообщении. Важно отметить, что для расшифровки сообщения, зашифрованного шифром Виженера, используется применение ключевого слова в обратном порядке, что позволяет восстановить исходный текст.

Одним из недостатков шифра Виженера является его уязвимость к атакам с использованием повторяющихся ключей, что может снизить его безопасность. Шифр был разработан известным математиком и криптографом Жаном Виженером, который предложил этот метод в 19 веке.

Для повышения безопасности шифра Виженера рекомендуется использование длинного и случайного ключевого слова, что делает его более устойчивым к криптоанализу.

Эти факты встречаются в вопросах 31-38.
        "},
    };

    // Метод Start вызывается при инициализации объекта. Он очищает текстовое поле и создает кнопки для каждого шифра.
    void Start()
    {
        textDisplay.text = "";

        foreach (var (cypherName, fact) in facts)
        {
            AddButton(cypherName, fact);
        }
    }

    // Метод AddButton создает кнопку с заданным текстом и назначает ей действие при нажатии.
    void AddButton(string buttonText, string text)
    {
        GameObject button = Instantiate(buttonPrefab, scrollViewContentTransform);

        Button buttonComponent = button.GetComponent<Button>();
        TextMeshProUGUI buttonTextComponent = button.GetComponentInChildren<TextMeshProUGUI>();
        buttonTextComponent.text = buttonText;
        buttonTextComponent.fontSize = 45;

        RectTransform buttonRectTransform = button.GetComponent<RectTransform>();
        buttonRectTransform.sizeDelta = new Vector2(buttonRectTransform.sizeDelta.x, 100);

        buttonComponent.onClick.AddListener(() => textDisplay.text = text);
    }
}
