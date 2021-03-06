﻿



using InitializingDBFromXML.Model;
using System;
using System.IO;
using System.Linq;
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://v8.1c.ru/messages")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://v8.1c.ru/messages", IsNullable = false)]
public partial class Message
{

    private MessageHeader headerField;

    private MessageBody bodyField;

    /// <remarks/>
    public MessageHeader Header
    {
        get
        {
            return this.headerField;
        }
        set
        {
            this.headerField = value;
        }
    }

    /// <remarks/>
    public MessageBody Body
    {
        get
        {
            return this.bodyField;
        }
        set
        {
            this.bodyField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://v8.1c.ru/messages")]
public partial class MessageHeader
{

    private string exchangePlanField;

    private string toField;

    private string fromField;

    private byte messageNoField;

    private byte receivedNoField;

    /// <remarks/>
    public string ExchangePlan
    {
        get
        {
            return this.exchangePlanField;
        }
        set
        {
            this.exchangePlanField = value;
        }
    }

    /// <remarks/>
    public string To
    {
        get
        {
            return this.toField;
        }
        set
        {
            this.toField = value;
        }
    }

    /// <remarks/>
    public string From
    {
        get
        {
            return this.fromField;
        }
        set
        {
            this.fromField = value;
        }
    }

    /// <remarks/>
    public byte MessageNo
    {
        get
        {
            return this.messageNoField;
        }
        set
        {
            this.messageNoField = value;
        }
    }

    /// <remarks/>
    public byte ReceivedNo
    {
        get
        {
            return this.receivedNoField;
        }
        set
        {
            this.receivedNoField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://v8.1c.ru/messages")]
public partial class MessageBody
{

    private ОрганизационнаяСтруктураПодразделение[] организационнаяСтруктураField;

    private СотрудникиСотрудник[] сотрудникиField;

    private ПроектыПроект[] проектыField;

    private НеявкиДокумент[] неявкиField;

    private ВременноИсполняющиеОбязанностиДокумент[] временноИсполняющиеОбязанностиField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace = "")]
    [System.Xml.Serialization.XmlArrayItemAttribute("Подразделение", IsNullable = false)]
    public ОрганизационнаяСтруктураПодразделение[] ОрганизационнаяСтруктура
    {
        get
        {
            return this.организационнаяСтруктураField;
        }
        set
        {
            this.организационнаяСтруктураField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace = "")]
    [System.Xml.Serialization.XmlArrayItemAttribute("Сотрудник", IsNullable = false)]
    public СотрудникиСотрудник[] Сотрудники
    {
        get
        {
            return this.сотрудникиField;
        }
        set
        {
            this.сотрудникиField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace = "")]
    [System.Xml.Serialization.XmlArrayItemAttribute("Проект", IsNullable = false)]
    public ПроектыПроект[] Проекты
    {
        get
        {
            return this.проектыField;
        }
        set
        {
            this.проектыField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace = "")]
    [System.Xml.Serialization.XmlArrayItemAttribute("Документ", IsNullable = false)]
    public НеявкиДокумент[] Неявки
    {
        get
        {
            return this.неявкиField;
        }
        set
        {
            this.неявкиField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace = "")]
    [System.Xml.Serialization.XmlArrayItemAttribute("Документ", IsNullable = false)]
    public ВременноИсполняющиеОбязанностиДокумент[] ВременноИсполняющиеОбязанности
    {
        get
        {
            return this.временноИсполняющиеОбязанностиField;
        }
        set
        {
            this.временноИсполняющиеОбязанностиField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ОрганизационнаяСтруктураПодразделение
{

    private string наименованиеField;

    private string кодField;

    private string кодРодителяField;

    private string пометкаУдаленияField;

    private string неактивноеField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Наименование
    {
        get
        {
            return this.наименованиеField;
        }
        set
        {
            this.наименованиеField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Код
    {
        get
        {
            return this.кодField;
        }
        set
        {
            this.кодField = XMLDataTypeConverter.DiscardZeros(value); 
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string КодРодителя
    {
        get
        {
            return this.кодРодителяField;
        }
        set
        {
            this.кодРодителяField = XMLDataTypeConverter.DiscardZeros(value);
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ПометкаУдаления
    {
        get
        {
            return this.пометкаУдаленияField;
        }
        set
        {
            this.пометкаУдаленияField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Неактивное
    {
        get
        {
            return this.неактивноеField;
        }
        set
        {
            this.неактивноеField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class СотрудникиСотрудник
{

    private СотрудникиСотрудникЗаписьКадровойИстории[] кадроваяИсторияField;

    public string кодField;

    private string табельныйНомерField;

    public string фИОField;

    private ushort кодПодразделенияField;

    private string наименованиеПодразделенияField;

    private string должностьField;

    private string ставкаField;

    private string принятField;

    private string уволенField;

    private string видЗанятостиField;

    private string актуальностьField;

    private string кодФизЛицоField;

    private string датаРожденияField;

    private string документВидField;

    private string документСерияField;

    private uint документНомерField;

    private string документДатаВыдачиField;

    private string документКемВыданField;

    private string документКодПодразделенияField;

    private string признакПField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ЗаписьКадровойИстории", IsNullable = false)]
    public СотрудникиСотрудникЗаписьКадровойИстории[] КадроваяИстория
    {
        get
        {
            return this.кадроваяИсторияField;
        }
        set
        {
            this.кадроваяИсторияField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Код
    {
        get
        {
            return this.кодField;
        }
        set
        {
            this.кодField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ТабельныйНомер
    {
        get
        {
            return this.табельныйНомерField;
        }
        set
        {
          
            this.табельныйНомерField = XMLDataTypeConverter.DiscardZeros(value); 
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ФИО
    {
        get
        {
            return this.фИОField;
        }
        set
        {
            this.фИОField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort КодПодразделения
    {
        get
        {
            return this.кодПодразделенияField;
        }
        set
        {
            this.кодПодразделенияField =value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string НаименованиеПодразделения
    {
        get
        {
            return this.наименованиеПодразделенияField;
        }
        set
        {
            this.наименованиеПодразделенияField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Должность
    {
        get
        {
            return this.должностьField;
        }
        set
        {
            this.должностьField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Ставка
    {
        get
        {
            return this.ставкаField;
        }
        set
        {
            this.ставкаField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Принят
    {
        get
        {
            return this.принятField;
        }
        set
        {
            this.принятField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Уволен
    {
        get
        {
            return this.уволенField;
        }
        set
        {
            this.уволенField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ВидЗанятости
    {
        get
        {
            return this.видЗанятостиField;
        }
        set
        {
            this.видЗанятостиField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Актуальность
    {
        get
        {
            return this.актуальностьField;
        }
        set
        {
            this.актуальностьField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string КодФизЛицо
    {
        get
        {
            return this.кодФизЛицоField;
        }
        set
        {
            this.кодФизЛицоField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаРождения
    {
        get
        {
            return this.датаРожденияField;
        }
        set
        {
            this.датаРожденияField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДокументВид
    {
        get
        {
            return this.документВидField;
        }
        set
        {
            this.документВидField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДокументСерия
    {
        get
        {
            return this.документСерияField;
        }
        set
        {
            this.документСерияField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint ДокументНомер
    {
        get
        {
            return this.документНомерField;
        }
        set
        {
            this.документНомерField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДокументДатаВыдачи
    {
        get
        {
            return this.документДатаВыдачиField;
        }
        set
        {
            this.документДатаВыдачиField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДокументКемВыдан
    {
        get
        {
            return this.документКемВыданField;
        }
        set
        {
            this.документКемВыданField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДокументКодПодразделения
    {
        get
        {
            return this.документКодПодразделенияField;
        }
        set
        {
            this.документКодПодразделенияField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ПризнакП
    {
        get
        {
            return this.признакПField;
        }
        set
        {
            this.признакПField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class СотрудникиСотрудникЗаписьКадровойИстории
{

    private string датаField;

    private ushort кодПодразделенияField;

    private string наименованиеПодразделенияField;

    private string должностьField;

    private string ставкаField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Дата
    {
        get
        {
            return this.датаField;
        }
        set
        {
            this.датаField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort КодПодразделения
    {
        get
        {
            return this.кодПодразделенияField;
        }
        set
        {
            this.кодПодразделенияField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string НаименованиеПодразделения
    {
        get
        {
            return this.наименованиеПодразделенияField;
        }
        set
        {
            this.наименованиеПодразделенияField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Должность
    {
        get
        {
            return this.должностьField;
        }
        set
        {
            this.должностьField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Ставка
    {
        get
        {
            return this.ставкаField;
        }
        set
        {
            this.ставкаField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ПроектыПроект
{

    private string наименованиеField;

    private string кодField;

    private string номерField;

    private string шифрField;

    private string номерДоговораField;

    private string описаниеField;

    private string статусField;

    private string индексИзделияПоТЗField;

    private string сокращенныеНаименованияИзделияИзСоставаУТКПоТЗField;

    private string датаНачалаField;

    private string датаОкончанияField;

    private string фактическаяДатаНачалаField;

    private string фактическаяДатаОкончанияField;

    private string датаПредоставленияПланГрафикаРаботField;

    private string удаленField;

    private string кодРуководителяПроектаField;

    private string кодФизЛицоРуководителяПроектаField;

    private string фИОРуководителяПроектаField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Наименование
    {
        get
        {
            return this.наименованиеField;
        }
        set
        {
            this.наименованиеField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Код
    {
        get
        {
            return this.кодField;
        }
        set
        {
            this.кодField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Номер
    {
        get
        {
            return this.номерField;
        }
        set
        {
            this.номерField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Шифр
    {
        get
        {
            return this.шифрField;
        }
        set
        {
            this.шифрField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string НомерДоговора
    {
        get
        {
            return this.номерДоговораField;
        }
        set
        {
            this.номерДоговораField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Описание
    {
        get
        {
            return this.описаниеField;
        }
        set
        {
            this.описаниеField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Статус
    {
        get
        {
            return this.статусField;
        }
        set
        {
            this.статусField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ИндексИзделияПоТЗ
    {
        get
        {
            return this.индексИзделияПоТЗField;
        }
        set
        {
            this.индексИзделияПоТЗField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string СокращенныеНаименованияИзделияИзСоставаУТКПоТЗ
    {
        get
        {
            return this.сокращенныеНаименованияИзделияИзСоставаУТКПоТЗField;
        }
        set
        {
            this.сокращенныеНаименованияИзделияИзСоставаУТКПоТЗField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаНачала
    {
        get
        {
            return this.датаНачалаField;
        }
        set
        {
            this.датаНачалаField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаОкончания
    {
        get
        {
            return this.датаОкончанияField;
        }
        set
        {
            this.датаОкончанияField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ФактическаяДатаНачала
    {
        get
        {
            return this.фактическаяДатаНачалаField;
        }
        set
        {
            this.фактическаяДатаНачалаField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ФактическаяДатаОкончания
    {
        get
        {
            return this.фактическаяДатаОкончанияField;
        }
        set
        {
            this.фактическаяДатаОкончанияField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаПредоставленияПланГрафикаРабот
    {
        get
        {
            return this.датаПредоставленияПланГрафикаРаботField;
        }
        set
        {
            this.датаПредоставленияПланГрафикаРаботField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Удален
    {
        get
        {
            return this.удаленField;
        }
        set
        {
            this.удаленField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string КодРуководителяПроекта
    {
        get
        {
            return this.кодРуководителяПроектаField;
        }
        set
        {
            this.кодРуководителяПроектаField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string КодФизЛицоРуководителяПроекта
    {
        get
        {
            return this.кодФизЛицоРуководителяПроектаField;
        }
        set
        {
            this.кодФизЛицоРуководителяПроектаField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ФИОРуководителяПроекта
    {
        get
        {
            return this.фИОРуководителяПроектаField;
        }
        set
        {
            this.фИОРуководителяПроектаField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class НеявкиДокумент
{

    private НеявкиДокументСтрока[] строкаField;

    private string кодField;

    private string проведенField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Строка")]
    public НеявкиДокументСтрока[] Строка
    {
        get
        {
            return this.строкаField;
        }
        set
        {
            this.строкаField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Код
    {
        get
        {
            return this.кодField;
        }
        set
        {
            this.кодField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Проведен
    {
        get
        {
            return this.проведенField;
        }
        set
        {
            this.проведенField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class НеявкиДокументСтрока
{

    private string кодField;

    private string кодФизЛицоField;

    private string фИОField;

    private string датаНачалаField;

    private string датаОкончанияField;

    private string причинаField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Код
    {
        get
        {
            return this.кодField;
        }
        set
        {
            this.кодField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string КодФизЛицо
    {
        get
        {
            return this.кодФизЛицоField;
        }
        set
        {
            this.кодФизЛицоField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ФИО
    {
        get
        {
            return this.фИОField;
        }
        set
        {
            this.фИОField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаНачала
    {
        get
        {
            return this.датаНачалаField;
        }
        set
        {
            this.датаНачалаField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаОкончания
    {
        get
        {
            return this.датаОкончанияField;
        }
        set
        {
            this.датаОкончанияField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Причина
    {
        get
        {
            return this.причинаField;
        }
        set
        {
            this.причинаField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ВременноИсполняющиеОбязанностиДокумент
{

    private string кодField;

    private string проведенField;

    private string кодФизЛицоСотрудникаField;

    private string фИОСотрудникаField;

    private string кодФизЛицоИсполняющегоОбязанностиField;

    private string фИОИсполняющегоОбязанностиField;

    private string датаНачалаField;

    private string датаОкончанияField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Код
    {
        get
        {
            return this.кодField;
        }
        set
        {
            this.кодField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Проведен
    {
        get
        {
            return this.проведенField;
        }
        set
        {
            this.проведенField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string КодФизЛицоСотрудника
    {
        get
        {
            return this.кодФизЛицоСотрудникаField;
        }
        set
        {
            this.кодФизЛицоСотрудникаField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ФИОСотрудника
    {
        get
        {
            return this.фИОСотрудникаField;
        }
        set
        {
            this.фИОСотрудникаField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string КодФизЛицоИсполняющегоОбязанности
    {
        get
        {
            return this.кодФизЛицоИсполняющегоОбязанностиField;
        }
        set
        {
            this.кодФизЛицоИсполняющегоОбязанностиField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ФИОИсполняющегоОбязанности
    {
        get
        {
            return this.фИОИсполняющегоОбязанностиField;
        }
        set
        {
            this.фИОИсполняющегоОбязанностиField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаНачала
    {
        get
        {
            return this.датаНачалаField;
        }
        set
        {
            this.датаНачалаField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаОкончания
    {
        get
        {
            return this.датаОкончанияField;
        }
        set
        {
            this.датаОкончанияField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class ОрганизационнаяСтруктура
{

    private ОрганизационнаяСтруктураПодразделение[] подразделениеField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Подразделение")]
    public ОрганизационнаяСтруктураПодразделение[] Подразделение
    {
        get
        {
            return this.подразделениеField;
        }
        set
        {
            this.подразделениеField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class Сотрудники
{

    private СотрудникиСотрудник[] сотрудникField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Сотрудник")]
    public СотрудникиСотрудник[] Сотрудник
    {
        get
        {
            return this.сотрудникField;
        }
        set
        {
            this.сотрудникField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class Проекты
{

    private ПроектыПроект[] проектField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Проект")]
    public ПроектыПроект[] Проект
    {
        get
        {
            return this.проектField;
        }
        set
        {
            this.проектField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class Неявки
{

    private НеявкиДокумент[] документField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Документ")]
    public НеявкиДокумент[] Документ
    {
        get
        {
            return this.документField;
        }
        set
        {
            this.документField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class ВременноИсполняющиеОбязанности
{

    private ВременноИсполняющиеОбязанностиДокумент[] документField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Документ")]
    public ВременноИсполняющиеОбязанностиДокумент[] Документ
    {
        get
        {
            return this.документField;
        }
        set
        {
            this.документField = value;
        }
    }


}

public static class DataLoader1C
{
  

    static public MessageBody Data { get; private set; }

    static public MessageHeader HeaderData { get; private set; }

    static  DataLoader1C()
    {
        _path = @"X:\Подразделения\СВиССА\Dinamika Extension\DB\Export_1C_Full.xml";
        Deserialize();
    }
    static string _path;
    static private void Deserialize()
    {
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Message));
        var body = (Message)serializer.Deserialize(new System.Xml.XmlTextReader(_path));
        Data = body.Body;
        HeaderData = body.Header;
    }

    static public void SerializeFileXML<T>(T data, string nameFileXML)
    {
        var serializer = new System.Xml.Serialization.XmlSerializer((data.GetType()));
        var newxml = System.IO.File.Create(nameFileXML);
        serializer.Serialize(newxml, data);
        newxml.Close();
    }
}