import { Profile } from "./Profile.js"
import { Vault } from "./Vault.js"

export class Keep {
    constructor(data) {
        this.id = data.id
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.views = data.views
        this.kept = data.kept
        this.creatorId = data.creatorId
        this.creator = new Profile(data.creator)
        this.vault = new Vault(data.vault)
    }
}