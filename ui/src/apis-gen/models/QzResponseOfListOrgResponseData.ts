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

import type { ListOrgResponse } from './ListOrgResponse';
import {
    instanceOfListOrgResponse,
    ListOrgResponseFromJSON,
    ListOrgResponseFromJSONTyped,
    ListOrgResponseToJSON,
} from './ListOrgResponse';

/**
 * @type QzResponseOfListOrgResponseData
 * 
 * @export
 */
export type QzResponseOfListOrgResponseData = ListOrgResponse;

export function QzResponseOfListOrgResponseDataFromJSON(json: any): QzResponseOfListOrgResponseData {
    return QzResponseOfListOrgResponseDataFromJSONTyped(json, false);
}

export function QzResponseOfListOrgResponseDataFromJSONTyped(json: any, ignoreDiscriminator: boolean): QzResponseOfListOrgResponseData {
    if (json == null) {
        return json;
    }
    return ListOrgResponseFromJSONTyped(json, true);
}

export function QzResponseOfListOrgResponseDataToJSON(value?: QzResponseOfListOrgResponseData | null): any {
    if (value == null) {
        return value;
    }

    if (instanceOfListOrgResponse(value)) {
        return ListOrgResponseToJSON(value as ListOrgResponse);
    }

    return {};
}
