Namespace DataType

    Public Class SessionInfo

        Private SessionCode As String
        Public Property m_sessionCode() As String
            Get
                Return SessionCode
            End Get
            Set(ByVal value As String)
                SessionCode = value
            End Set
        End Property

        Private EndCustomerLink As String
        Public Property m_EndCustomerLink() As String
            Get
                Return EndCustomerLink
            End Get
            Set(ByVal value As String)
                EndCustomerLink = value
            End Set
        End Property


        Friend Property SupporterLink As String
        Friend Property ValidUntil As DateTime?
        Friend Property GroupId As String
        Friend Property Description As String
        Friend Property EndCustomer As Customer
        Friend Property AssignedUserId As String
        Friend Property CreatedAt As DateTime?
        Friend Property SessionState As String




    End Class
End Namespace