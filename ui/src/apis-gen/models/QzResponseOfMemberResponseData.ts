/* tslint:disable */
/* eslint-disable */
/**
 * 轻舟 RestAPI
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

/**
 * @type QzResponseOfMemberResponseData
 * 
 * @export
 */
export type QzResponseOfMemberResponseData = object;

export function QzResponseOfMemberResponseDataFromJSON(json: any): QzResponseOfMemberResponseData {
    return QzResponseOfMemberResponseDataFromJSONTyped(json, false);
}

export function QzResponseOfMemberResponseDataFromJSONTyped(json: any, ignoreDiscriminator: boolean): QzResponseOfMemberResponseData {
    if (json == null) {
        return json;
    }
    return objectFromJSONTyped(json, true);
}

export function QzResponseOfMemberResponseDataToJSON(value?: QzResponseOfMemberResponseData | null): any {
    if (value == null) {
        return value;
    }

    if (instanceOfobject(value)) {
        return objectToJSON(value as object);
    }

    return {};
}
