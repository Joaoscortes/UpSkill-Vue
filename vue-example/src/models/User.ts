export interface IUser {
  "id"?: string;
  "name": string;
  "email": string;
  "password": string;
}

export default class User {
  constructor(data?: IUser) {
    Object.assign(this, data)
  }
}