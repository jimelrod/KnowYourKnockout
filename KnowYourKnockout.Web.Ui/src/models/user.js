export class User {
    id = '';
    emailAddress = '';
    firstName = '';
    lastName = '';
    isActive = false;
    joinedOn = new Date(0,0);

    constructor(obj) {
        this.id = obj.id;
        this.emailAddress = obj.emailAddress;
        this.firstName = obj.firstName;
        this.lastName = obj.lastName;
        this.isActive = obj.isActive;
        this.joinedOn = obj.joinedOn;
    }
}