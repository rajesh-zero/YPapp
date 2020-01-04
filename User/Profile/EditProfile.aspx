<%@ Page Title="" Language="C#" MasterPageFile="~/User/Profile/Profile.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="User_Profile_EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="editprofile" class="row" runat="server">
        <div class="panel panel-default">
            <div style="padding: 20px;">
                <div class="form-group row">
                    <div class="col-sm-2">
                        Name :
                    </div>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtName" class="form-control" Style="width: 60%;" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter name" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-2">
                        Birth Date :
                    </div>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDob" class="form-control" Style="width: 60%;" runat="server" TextMode="Date"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Date of birth" ControlToValidate="txtDob" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-2">
                        Gender :
                    </div>
                    <div class="col-sm-10">
                        <asp:RadioButton ID="rbMale" runat="server" Text="Male" ValidationGroup="rbgender" GroupName="gender" Checked="True" />&nbsp;<asp:RadioButton ID="rbFemale" runat="server" Text="Female" ValidationGroup="rbgender" GroupName="gender" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-2">
                        Mobile no :
                    </div>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtMobile" class="form-control" Style="width: 60%;" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter mobile no" ControlToValidate="txtMobile" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please Enter valid mobile no" ControlToValidate="txtMobile" ForeColor="Red" ValidationExpression="[0-9]{10}" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-2">
                        Country :
                    </div>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="Country" class="form-control" Style="width: 60%;" runat="server">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem Value="Afghanistan">                             Afghanistan</asp:ListItem>
                            <asp:ListItem Value="Albania">                                 Albania</asp:ListItem>
                            <asp:ListItem Value="Algeria">                                 Algeria</asp:ListItem>
                            <asp:ListItem Value="American Samoa">                          American Samoa</asp:ListItem>
                            <asp:ListItem Value="Andorra">                                 Andorra</asp:ListItem>
                            <asp:ListItem Value="Angola">                                  Angola</asp:ListItem>
                            <asp:ListItem Value="Anguilla">                                Anguilla</asp:ListItem>
                            <asp:ListItem Value="Antarctica">                              Antarctica</asp:ListItem>
                            <asp:ListItem Value="Antigua And Barbuda">                     Antigua And Barbuda</asp:ListItem>
                            <asp:ListItem Value="Argentina">                               Argentina</asp:ListItem>
                            <asp:ListItem Value="Armenia">                                 Armenia</asp:ListItem>
                            <asp:ListItem Value="Aruba">                                   Aruba</asp:ListItem>
                            <asp:ListItem Value="Australia">                               Australia</asp:ListItem>
                            <asp:ListItem Value="Austria">                                 Austria</asp:ListItem>
                            <asp:ListItem Value="Azerbaijan">                              Azerbaijan</asp:ListItem>
                            <asp:ListItem Value="Bahamas">                                 Bahamas</asp:ListItem>
                            <asp:ListItem Value="Bahrain">                                 Bahrain</asp:ListItem>
                            <asp:ListItem Value="Bangladesh">                              Bangladesh</asp:ListItem>
                            <asp:ListItem Value="Barbados">                                Barbados</asp:ListItem>
                            <asp:ListItem Value="Belarus">                                 Belarus</asp:ListItem>
                            <asp:ListItem Value="Belgium">                                 Belgium</asp:ListItem>
                            <asp:ListItem Value="Belize">                                  Belize</asp:ListItem>
                            <asp:ListItem Value="Benin">                                   Benin</asp:ListItem>
                            <asp:ListItem Value="Bermuda">                                 Bermuda</asp:ListItem>
                            <asp:ListItem Value="Bhutan">                                  Bhutan</asp:ListItem>
                            <asp:ListItem Value="Bolivia">                                 Bolivia</asp:ListItem>
                            <asp:ListItem Value="Bosnia And Herzegowina">                  Bosnia And Herzegowina</asp:ListItem>
                            <asp:ListItem Value="Botswana">                                Botswana</asp:ListItem>
                            <asp:ListItem Value="Bouvet Island">                           Bouvet Island</asp:ListItem>
                            <asp:ListItem Value="Brazil">                                  Brazil</asp:ListItem>
                            <asp:ListItem Value="British Indian Ocean Territory">          British Indian Ocean Territo</asp:ListItem>
                            <asp:ListItem Value="Brunei Darussalam">                       Brunei Darussalam</asp:ListItem>
                            <asp:ListItem Value="Bulgaria">                                Bulgaria</asp:ListItem>
                            <asp:ListItem Value="Burkina Faso">                            Burkina Faso</asp:ListItem>
                            <asp:ListItem Value="Burundi">                                 Burundi</asp:ListItem>
                            <asp:ListItem Value="Cambodia">                                Cambodia</asp:ListItem>
                            <asp:ListItem Value="Cameroon">                                Cameroon</asp:ListItem>
                            <asp:ListItem Value="Canada">                                  Canada</asp:ListItem>
                            <asp:ListItem Value="Cape Verde">                              Cape Verde</asp:ListItem>
                            <asp:ListItem Value="Cayman Islands">                          Cayman Islands</asp:ListItem>
                            <asp:ListItem Value="Central African Republic">                Central African Republic</asp:ListItem>
                            <asp:ListItem Value="Chad">                                    Chad</asp:ListItem>
                            <asp:ListItem Value="Chile">                                   Chile</asp:ListItem>
                            <asp:ListItem Value="China">                                   China</asp:ListItem>
                            <asp:ListItem Value="Christmas Island">                        Christmas Island</asp:ListItem>
                            <asp:ListItem Value="Cocos (Keeling) Islands">                 Cocos (Keeling) Islands</asp:ListItem>
                            <asp:ListItem Value="Colombia">                                Colombia</asp:ListItem>
                            <asp:ListItem Value="Comoros">                                 Comoros</asp:ListItem>
                            <asp:ListItem Value="Congo">                                   Congo</asp:ListItem>
                            <asp:ListItem Value="Cook Islands">                            Cook Islands</asp:ListItem>
                            <asp:ListItem Value="Costa Rica">                              Costa Rica</asp:ListItem>
                            <asp:ListItem Value="Cote D'Ivoire">                           Cote D'Ivoire</asp:ListItem>
                            <asp:ListItem Value="Croatia (Local Name: Hrvatska)">          Croatia (Local Name: Hrvatsk</asp:ListItem>
                            <asp:ListItem Value="Cuba">                                    Cuba</asp:ListItem>
                            <asp:ListItem Value="Cyprus">                                  Cyprus</asp:ListItem>
                            <asp:ListItem Value="Czech Republic">                          Czech Republic</asp:ListItem>
                            <asp:ListItem Value="Denmark">                                 Denmark</asp:ListItem>
                            <asp:ListItem Value="Djibouti">                                Djibouti</asp:ListItem>
                            <asp:ListItem Value="Dominica">                                Dominica</asp:ListItem>
                            <asp:ListItem Value="Dominican Republic">                      Dominican Republic</asp:ListItem>
                            <asp:ListItem Value="East Timor">                              East Timor</asp:ListItem>
                            <asp:ListItem Value="Ecuador">                                 Ecuador</asp:ListItem>
                            <asp:ListItem Value="Egypt">                                   Egypt</asp:ListItem>
                            <asp:ListItem Value="El Salvador">                             El Salvador</asp:ListItem>
                            <asp:ListItem Value="Equatorial Guinea">                       Equatorial Guinea</asp:ListItem>
                            <asp:ListItem Value="Eritrea">                                 Eritrea</asp:ListItem>
                            <asp:ListItem Value="Estonia">                                 Estonia</asp:ListItem>
                            <asp:ListItem Value="Ethiopia">                                Ethiopia</asp:ListItem>
                            <asp:ListItem Value="Falkland Islands (Malvinas)">             Falkland Islands (Malvinas)</asp:ListItem>
                            <asp:ListItem Value="Faroe Islands">                           Faroe Islands</asp:ListItem>
                            <asp:ListItem Value="Fiji">                                    Fiji</asp:ListItem>
                            <asp:ListItem Value="Finland">                                 Finland</asp:ListItem>
                            <asp:ListItem Value="France">                                  France</asp:ListItem>
                            <asp:ListItem Value="French Guiana">                           French Guiana</asp:ListItem>
                            <asp:ListItem Value="French Polynesia">                        French Polynesia</asp:ListItem>
                            <asp:ListItem Value="French Southern Territories">             French Southern Territories</asp:ListItem>
                            <asp:ListItem Value="Gabon">                                   Gabon</asp:ListItem>
                            <asp:ListItem Value="Gambia">                                  Gambia</asp:ListItem>
                            <asp:ListItem Value="Georgia">                                 Georgia</asp:ListItem>
                            <asp:ListItem Value="Germany">                                 Germany</asp:ListItem>
                            <asp:ListItem Value="Ghana">                                   Ghana</asp:ListItem>
                            <asp:ListItem Value="Gibraltar">                               Gibraltar</asp:ListItem>
                            <asp:ListItem Value="Greece">                                  Greece</asp:ListItem>
                            <asp:ListItem Value="Greenland">                               Greenland</asp:ListItem>
                            <asp:ListItem Value="Grenada">                                 Grenada</asp:ListItem>
                            <asp:ListItem Value="Guadeloupe">                              Guadeloupe</asp:ListItem>
                            <asp:ListItem Value="Guam">                                    Guam</asp:ListItem>
                            <asp:ListItem Value="Guatemala">                               Guatemala</asp:ListItem>
                            <asp:ListItem Value="Guinea">                                  Guinea</asp:ListItem>
                            <asp:ListItem Value="Guinea-Bissau">                           Guinea-Bissau</asp:ListItem>
                            <asp:ListItem Value="Guyana">                                  Guyana</asp:ListItem>
                            <asp:ListItem Value="Haiti">                                   Haiti</asp:ListItem>
                            <asp:ListItem Value="Heard And Mc Donald Islands">             Heard And Mc Donald Islands</asp:ListItem>
                            <asp:ListItem Value="Holy See (Vatican City State)">           Holy See (Vatican City State</asp:ListItem>
                            <asp:ListItem Value="Honduras">                                Honduras</asp:ListItem>
                            <asp:ListItem Value="Hong Kong">                               Hong Kong</asp:ListItem>
                            <asp:ListItem Value="Hungary">                                 Hungary</asp:ListItem>
                            <asp:ListItem Value="Icel And">                                Icel And</asp:ListItem>
                            <asp:ListItem Value="India">                                   India</asp:ListItem>
                            <asp:ListItem Value="Indonesia">                               Indonesia</asp:ListItem>
                            <asp:ListItem Value="Iran (Islamic Republic Of)">              Iran (Islamic Republic Of)</asp:ListItem>
                            <asp:ListItem Value="Iraq">                                    Iraq</asp:ListItem>
                            <asp:ListItem Value="Ireland">                                 Ireland</asp:ListItem>
                            <asp:ListItem Value="Israel">                                  Israel</asp:ListItem>
                            <asp:ListItem Value="Italy">                                   Italy</asp:ListItem>
                            <asp:ListItem Value="Jamaica">                                 Jamaica</asp:ListItem>
                            <asp:ListItem Value="Japan">                                   Japan</asp:ListItem>
                            <asp:ListItem Value="Jordan">                                  Jordan</asp:ListItem>
                            <asp:ListItem Value="Kazakhstan">                              Kazakhstan</asp:ListItem>
                            <asp:ListItem Value="Kenya">                                   Kenya</asp:ListItem>
                            <asp:ListItem Value="Kiribati">                                Kiribati</asp:ListItem>
                            <asp:ListItem Value="Latvia">                                  Latvia</asp:ListItem>
                            <asp:ListItem Value="Lebanon">                                 Lebanon</asp:ListItem>
                            <asp:ListItem Value="Lesotho">                                 Lesotho</asp:ListItem>
                            <asp:ListItem Value="Liberia">                                 Liberia</asp:ListItem>
                            <asp:ListItem Value="Libyan Arab Jamahiriya">                  Libyan Arab Jamahiriya</asp:ListItem>
                            <asp:ListItem Value="Liechtenstein">                           Liechtenstein</asp:ListItem>
                            <asp:ListItem Value="Lithuania">                               Lithuania</asp:ListItem>
                            <asp:ListItem Value="Luxembourg">                              Luxembourg</asp:ListItem>
                            <asp:ListItem Value="Macau">                                   Macau</asp:ListItem>
                            <asp:ListItem Value="Macedonia">                               Macedonia</asp:ListItem>
                            <asp:ListItem Value="Madagascar">                              Madagascar</asp:ListItem>
                            <asp:ListItem Value="Malawi">                                  Malawi</asp:ListItem>
                            <asp:ListItem Value="Malaysia">                                Malaysia</asp:ListItem>
                            <asp:ListItem Value="Maldives">                                Maldives</asp:ListItem>
                            <asp:ListItem Value="Mali">                                    Mali</asp:ListItem>
                            <asp:ListItem Value="Malta">                                   Malta</asp:ListItem>
                            <asp:ListItem Value="Marshall Islands">                        Marshall Islands</asp:ListItem>
                            <asp:ListItem Value="Martinique">                              Martinique</asp:ListItem>
                            <asp:ListItem Value="Mauritania">                              Mauritania</asp:ListItem>
                            <asp:ListItem Value="Mauritius">                               Mauritius</asp:ListItem>
                            <asp:ListItem Value="Mayotte">                                 Mayotte</asp:ListItem>
                            <asp:ListItem Value="Mexico">                                  Mexico</asp:ListItem>
                            <asp:ListItem Value="Micronesia, Federated States">            Micronesia, Federated States</asp:ListItem>
                            <asp:ListItem Value="Moldova, Republic Of">                    Moldova, Republic Of</asp:ListItem>
                            <asp:ListItem Value="Monaco">                                  Monaco</asp:ListItem>
                            <asp:ListItem Value="Mongolia">                                Mongolia</asp:ListItem>
                            <asp:ListItem Value="Montserrat">                              Montserrat</asp:ListItem>
                            <asp:ListItem Value="Morocco">                                 Morocco</asp:ListItem>
                            <asp:ListItem Value="Mozambique">                              Mozambique</asp:ListItem>
                            <asp:ListItem Value="Myanmar">                                 Myanmar</asp:ListItem>
                            <asp:ListItem Value="Namibia">                                 Namibia</asp:ListItem>
                            <asp:ListItem Value="Nauru">                                   Nauru</asp:ListItem>
                            <asp:ListItem Value="Nepal">                                   Nepal</asp:ListItem>
                            <asp:ListItem Value="Netherlands">                             Netherlands</asp:ListItem>
                            <asp:ListItem Value="Netherlands Ant Illes">                   Netherlands Ant Illes</asp:ListItem>
                            <asp:ListItem Value="New Caledonia">                           New Caledonia</asp:ListItem>
                            <asp:ListItem Value="New Zealand">                             New Zealand</asp:ListItem>
                            <asp:ListItem Value="Nicaragua">                               Nicaragua</asp:ListItem>
                            <asp:ListItem Value="Niger">                                   Niger</asp:ListItem>
                            <asp:ListItem Value="Nigeria">                                 Nigeria</asp:ListItem>
                            <asp:ListItem Value="Niue">                                    Niue</asp:ListItem>
                            <asp:ListItem Value="Norfolk Island">                          Norfolk Island</asp:ListItem>
                            <asp:ListItem Value="Northern Mariana Islands">                Northern Mariana Islands</asp:ListItem>
                            <asp:ListItem Value="Norway">                                  Norway</asp:ListItem>
                            <asp:ListItem Value="Oman">                                    Oman</asp:ListItem>
                            <asp:ListItem Value="Pakistan">                                Pakistan</asp:ListItem>
                            <asp:ListItem Value="Palau">                                   Palau</asp:ListItem>
                            <asp:ListItem Value="Panama">                                  Panama</asp:ListItem>
                            <asp:ListItem Value="Papua New Guinea">                        Papua New Guinea</asp:ListItem>
                            <asp:ListItem Value="Paraguay">                                Paraguay</asp:ListItem>
                            <asp:ListItem Value="Peru">                                    Peru</asp:ListItem>
                            <asp:ListItem Value="Philippines">                             Philippines</asp:ListItem>
                            <asp:ListItem Value="Pitcairn">                                Pitcairn</asp:ListItem>
                            <asp:ListItem Value="Poland">                                  Poland</asp:ListItem>
                            <asp:ListItem Value="Portugal">                                Portugal</asp:ListItem>
                            <asp:ListItem Value="Puerto Rico">                             Puerto Rico</asp:ListItem>
                            <asp:ListItem Value="Qatar">                                   Qatar</asp:ListItem>
                            <asp:ListItem Value="Reunion">                                 Reunion</asp:ListItem>
                            <asp:ListItem Value="Romania">                                 Romania</asp:ListItem>
                            <asp:ListItem Value="Russian Federation">                      Russian Federation</asp:ListItem>
                            <asp:ListItem Value="Rwanda">                                  Rwanda</asp:ListItem>
                            <asp:ListItem Value="Saint K Itts And Nevis">                  Saint K Itts And Nevis</asp:ListItem>
                            <asp:ListItem Value="Saint Lucia">                             Saint Lucia</asp:ListItem>
                            <asp:ListItem Value="Saint Vincent, The Grenadines">           Saint Vincent, The Grenadine</asp:ListItem>
                            <asp:ListItem Value="Samoa">                                   Samoa</asp:ListItem>
                            <asp:ListItem Value="San Marino">                              San Marino</asp:ListItem>
                            <asp:ListItem Value="Sao Tome And Principe">                   Sao Tome And Principe</asp:ListItem>
                            <asp:ListItem Value="Saudi Arabia">                            Saudi Arabia</asp:ListItem>
                            <asp:ListItem Value="Senegal">                                 Senegal</asp:ListItem>
                            <asp:ListItem Value="Seychelles">                              Seychelles</asp:ListItem>
                            <asp:ListItem Value="Sierra Leone">                            Sierra Leone</asp:ListItem>
                            <asp:ListItem Value="Singapore">                               Singapore</asp:ListItem>
                            <asp:ListItem Value="Slovakia (Slovak Republic)">              Slovakia (Slovak Republic)</asp:ListItem>
                            <asp:ListItem Value="Slovenia">                                Slovenia</asp:ListItem>
                            <asp:ListItem Value="Solomon Islands">                         Solomon Islands</asp:ListItem>
                            <asp:ListItem Value="Somalia">                                 Somalia</asp:ListItem>
                            <asp:ListItem Value="South Africa">                            South Africa</asp:ListItem>
                            <asp:ListItem Value="South Georgia , S Sandwich Is.">          South Georgia , S Sandwich I</asp:ListItem>
                            <asp:ListItem Value="Spain">                                   Spain</asp:ListItem>
                            <asp:ListItem Value="Sri Lanka">                               Sri Lanka</asp:ListItem>
                            <asp:ListItem Value="St. Helena">                              St. Helena</asp:ListItem>
                            <asp:ListItem Value="St. Pierre And Miquelon">                 St. Pierre And Miquelon</asp:ListItem>
                            <asp:ListItem Value="Sudan">                                   Sudan</asp:ListItem>
                            <asp:ListItem Value="Suriname">                                Suriname</asp:ListItem>
                            <asp:ListItem Value="Svalbard, Jan Mayen Islands">             Svalbard, Jan Mayen Islands</asp:ListItem>
                            <asp:ListItem Value="Sw Aziland">                              Sw Aziland</asp:ListItem>
                            <asp:ListItem Value="Sweden">                                  Sweden</asp:ListItem>
                            <asp:ListItem Value="Switzerland">                             Switzerland</asp:ListItem>
                            <asp:ListItem Value="Syrian Arab Republic">                    Syrian Arab Republic</asp:ListItem>
                            <asp:ListItem Value="Taiwan">                                  Taiwan</asp:ListItem>
                            <asp:ListItem Value="Tajikistan">                              Tajikistan</asp:ListItem>
                            <asp:ListItem Value="Tanzania, United Republic Of">            Tanzania, United Republic Of</asp:ListItem>
                            <asp:ListItem Value="Thailand">                                Thailand</asp:ListItem>
                            <asp:ListItem Value="Togo">                                    Togo</asp:ListItem>
                            <asp:ListItem Value="Tokelau">                                 Tokelau</asp:ListItem>
                            <asp:ListItem Value="Tonga">                                   Tonga</asp:ListItem>
                            <asp:ListItem Value="Trinidad And Tobago">                     Trinidad And Tobago</asp:ListItem>
                            <asp:ListItem Value="Tunisia">                                 Tunisia</asp:ListItem>
                            <asp:ListItem Value="Turkey">                                  Turkey</asp:ListItem>
                            <asp:ListItem Value="Turkmenistan">                            Turkmenistan</asp:ListItem>
                            <asp:ListItem Value="Turks And Caicos Islands">                Turks And Caicos Islands</asp:ListItem>
                            <asp:ListItem Value="Tuvalu">                                  Tuvalu</asp:ListItem>
                            <asp:ListItem Value="Uganda">                                  Uganda</asp:ListItem>
                            <asp:ListItem Value="Ukraine">                                 Ukraine</asp:ListItem>
                            <asp:ListItem Value="United Arab Emirates">                    United Arab Emirates</asp:ListItem>
                            <asp:ListItem Value="United Kingdom">                          United Kingdom</asp:ListItem>
                            <asp:ListItem Value="United States">                           United States</asp:ListItem>
                            <asp:ListItem Value="United States Minor Is.">                 United States Minor Is.</asp:ListItem>
                            <asp:ListItem Value="Uruguay">                                 Uruguay</asp:ListItem>
                            <asp:ListItem Value="Uzbekistan">                              Uzbekistan</asp:ListItem>
                            <asp:ListItem Value="Vanuatu">                                 Vanuatu</asp:ListItem>
                            <asp:ListItem Value="Venezuela">                               Venezuela</asp:ListItem>
                            <asp:ListItem Value="Viet Nam">                                Viet Nam</asp:ListItem>
                            <asp:ListItem Value="Virgin Islands (British)">                Virgin Islands (British)</asp:ListItem>
                            <asp:ListItem Value="Virgin Islands (U.S.)">                   Virgin Islands (U.S.)</asp:ListItem>
                            <asp:ListItem Value="Wallis And Futuna Islands">               Wallis And Futuna Islands</asp:ListItem>
                            <asp:ListItem Value="Western Sahara">                          Western Sahara</asp:ListItem>
                            <asp:ListItem Value="Yemen">                                   Yemen</asp:ListItem>
                            <asp:ListItem Value="Yugoslavia">                              Yugoslavia</asp:ListItem>
                            <asp:ListItem Value="Zaire">                                   Zaire</asp:ListItem>
                            <asp:ListItem Value="Zambia">                                  Zambia</asp:ListItem>
                            <asp:ListItem Value="Zimbabwe">                                Zimbabwe</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Country" InitialValue="--Select--" runat="server" ErrorMessage="Please select Country" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-2">
                        About me:
                    </div>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtAboutme" class="form-control" Style="padding-right: 10px; resize: none;" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-5 col-sm-offset-6">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-warning btn-sm" CausesValidation="False" OnClick="btnCancel_Click" />&nbsp;
                       <asp:Button ID="btnUpdate" class="btn btn-primary btn-sm" runat="server" Text="Update Profile" OnClick="btnUpdate_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

