import { Injectable, signal } from "@angular/core";
import { Configuration } from "./configuration.model";

@Injectable({
  providedIn: "root",
})
export class ConfigurationStore {
  private readonly config = signal({
    apiUrl: "",
  });

  set(config: Configuration): void {
    this.config.set(config);
  }

  get<TResult>(projector: (config: Configuration) => TResult): TResult {
    return projector(this.config());
  }
}
