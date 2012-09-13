﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nhs.itk.hl7v3.rim;
using System.Xml.Serialization;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.xml;
using System.Xml;

namespace nhs.itk.hl7v3.cda.classes
{
    internal class r_Generic : RoleClass
    {
        internal string rootElement { get; set; }
        internal string templateId { get; set; }
        internal string templateText { get; set; }
        internal e_person assignedPerson;
        internal e_organisation representedOrganisation;
        internal e_device assignedDevice;

        internal r_Generic()
            : base()
        { }

        internal r_Generic(string classCode)
            : base(classCode)
        { }

        internal void InitPerson()
        {
            if (assignedPerson == null)
            {
                assignedPerson = new e_person("PSN", "INSTANCE");
            }
        }
        internal void InitOrganisation()
        {
            if (representedOrganisation == null)
            {
                representedOrganisation = new e_organisation("ORG", "INSTANCE");
            }
        }
        internal void InitDevice()
        {
            if (assignedDevice == null)
            {
                assignedDevice = new e_device("DEV", "INSTANCE");
            }
        }

        #region XML Serialization Members

        internal void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("classCode", ClassCode);

            its.TemplateSignpost(templateId + "#" + templateText, writer);
            writeXML(writer);

            if (assignedPerson != null)
            {
                writer.WriteStartElement("assignedPerson");
                assignedPerson.TemplateId = templateId;
                assignedPerson.TemplateText = "assignedPerson";
                assignedPerson.WriteXml(writer);
                writer.WriteEndElement();
            }

            if (assignedDevice != null)
            {
                writer.WriteStartElement("assignedAuthoringDevice");
                assignedDevice.TemplateId = templateId;
                assignedDevice.TemplateText = "assignedAuthoringDevice";
                assignedDevice.WriteXml(writer);
                writer.WriteEndElement();
            }

            if (representedOrganisation != null)
            {
                writer.WriteStartElement("representedOrganization");
                representedOrganisation.TemplateId = templateId;
                representedOrganisation.TemplateText = "representedOrganization";
                representedOrganisation.WriteXml(writer);
                writer.WriteEndElement();
            }
        }

        #endregion
    }
}