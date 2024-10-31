import { reactive } from 'vue'
// eslint-disable-next-line no-unused-vars
import { Keep } from './models/Keep.js'
// eslint-disable-next-line no-unused-vars
import { Vault } from './models/Vault.js'


// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,
  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,

  /** @type {Keep[]} */
  keeps: [],

  /** @type {Keep} */
  activeKeep: null,

  /** @type {Vault[]} */
  accountVaults: [],

  /** @type {Keep[]} */
  accountKeeps: [],
})

