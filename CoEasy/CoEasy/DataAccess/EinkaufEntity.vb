'------------------------------------------------------------------------------
' <auto-generated>
'     Der Code wurde von einer Vorlage generiert.
'
'     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
'     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class EinkaufEntity
    Public Property EinkaufIdPk As Integer
    Public Property Totalpreis As Decimal
    Public Property Status As String
    Public Property Erstelldatum As Date

    Public Overridable Property tblCoworker As ICollection(Of CoworkerEntity) = New HashSet(Of CoworkerEntity)
    Public Overridable Property tblEinkaufsposition As ICollection(Of EinkaufspositionEntity) = New HashSet(Of EinkaufspositionEntity)

End Class
