/* tslint:disable */
/* eslint-disable */
/**
 * Qz.WebApi
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


/**
 * 
 * @export
 */
export const ErrorCode = {
    NUMBER_0: 0
} as const;
export type ErrorCode = typeof ErrorCode[keyof typeof ErrorCode];


export function instanceOfErrorCode(value: any): boolean {
    return Object.values(ErrorCode).includes(value);
}

export function ErrorCodeFromJSON(json: any): ErrorCode {
    return ErrorCodeFromJSONTyped(json, false);
}

export function ErrorCodeFromJSONTyped(json: any, ignoreDiscriminator: boolean): ErrorCode {
    return json as ErrorCode;
}

export function ErrorCodeToJSON(value?: ErrorCode | null): any {
    return value as any;
}

