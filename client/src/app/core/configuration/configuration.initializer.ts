import { HttpClient } from '@angular/common/http'
import { inject } from '@angular/core'
import { Observable, tap } from 'rxjs'
import { Configuration } from './configuration.model'
import { ConfigurationStore } from './configuration.store'

export function configurationInitializer(
  url: string,
): () => Observable<Configuration> {
  return () => {
    const http = inject(HttpClient)
    const store = inject(ConfigurationStore)

    return http.get<Configuration>(url).pipe(tap((config) => store.set(config)))
  }
}
