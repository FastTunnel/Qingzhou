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

import { mapValues } from '../runtime';
/**
 * 
 * @export
 * @interface TodoDto
 */
export interface TodoDto {
    /**
     * 
     * @type {string}
     * @memberof TodoDto
     */
    id?: string;
    /**
     * 
     * @type {string}
     * @memberof TodoDto
     */
    title?: string;
    /**
     * 
     * @type {string}
     * @memberof TodoDto
     */
    summary?: string;
}

/**
 * Check if a given object implements the TodoDto interface.
 */
export function instanceOfTodoDto(value: object): boolean {
    return true;
}

export function TodoDtoFromJSON(json: any): TodoDto {
    return TodoDtoFromJSONTyped(json, false);
}

export function TodoDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): TodoDto {
    if (json == null) {
        return json;
    }
    return {
        
        'id': json['id'] == null ? undefined : json['id'],
        'title': json['title'] == null ? undefined : json['title'],
        'summary': json['summary'] == null ? undefined : json['summary'],
    };
}

export function TodoDtoToJSON(value?: TodoDto | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'id': value['id'],
        'title': value['title'],
        'summary': value['summary'],
    };
}

