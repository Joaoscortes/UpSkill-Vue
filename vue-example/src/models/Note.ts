export interface INote {
  "id"?: string;
  "message": string;
  "authorId": number;
  "created"?: string;
  "updated"?: string;
}

export default class Note {
  constructor(data?: INote) {
    Object.assign(this, data)
  }
}