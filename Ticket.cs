public class Ticket{
    public string ticketID, summary, status, priority, submitter, assigned, watching, severity;

    public Ticket(){
        this.ticketID="placeHolder";
        this.summary="placeHolder";
        this.status="placeHolder";
        this.priority="placeHolder";
        this.submitter="placeHolder";
        this.assigned="placeHolder";
        this.watching="placeHolder";
        this.severity="placeHolder";
    }
    public Ticket(string ticketID, string summary, string status, string priority, string submitter, string assigned, string watching, string severity){
        this.ticketID=ticketID;
        this.summary=summary;
        this.status=status;
        this.priority=priority;
        this.submitter=submitter;
        this.assigned=assigned;
        this.watching=watching;
        this.severity=severity;
    }
    public string returnString(){
        return ticketID+", "+summary+", "+status+", "+priority+", "+submitter+", "+assigned+", "+watching+", "+severity;
    }

}