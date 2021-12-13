declare module "partikulario" {
    export function withSideEffect(
        reducePropsToState: any,
        handleStateChangeOnClient: any,
        mapStateOnServer: any
    ): any;
    export var particlesJS: iParticlesJS;// = window["particlesJS"];
    interface iParticlesJS {

        (tag_id: string, path_config_json: object): void;
    }
    //export = withSideEffect;
}