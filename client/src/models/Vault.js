import { Keep } from "./Keep.js"
import { Profile } from "./Profile.js"

export class Vault {
    constructor(data) {
        this.id = data.id
        this.name = data.name
        this.description = data.description
        this.isPrivate = data.isPrivate
        this.img = data.img
        this.creatorId = data.creatorId
        this.creator = new Profile(data.creator)
        this.keeps = new Keep(data.keeps)
    }
}