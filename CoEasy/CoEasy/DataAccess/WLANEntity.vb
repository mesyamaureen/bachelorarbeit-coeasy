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

Partial Public Class WLANEntity
    Public Property WlanIdPk As Integer
    Public Property WlanCode As String

    Public Overridable Property tblEinkaufsposition As ICollection(Of EinkaufspositionEntity) = New HashSet(Of EinkaufspositionEntity)

End Class