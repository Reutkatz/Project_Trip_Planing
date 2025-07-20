export enum userRole {
    BusinessManager,
    User
  }
export class User {

    constructor(
        public id: number = 0,
        public name?: string,
        public email?: string,
        public password?: string,
        public role: userRole = userRole.User
       ) { }

       static fromJSON(json: any): User {
        return new User(json.id, json.name, json.email,json.password,json.role);
      }
}